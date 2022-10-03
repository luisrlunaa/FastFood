using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FastFoodDemo.Utils
{
    public static class PasswordEncrypter
    {
        private static string Key = "ZrcHYkTMr3Yr9I3Oq2qVLQaHi/ayxHTYsowGLwR9lsA=";
        private static string IV = "5EPCnjgr2sJ2h6Tm8VdZDw==".Substring(0, 16);

        public static string Encrypt(this string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return "";

            int PasswordIterations = 2;
            int KeySize = 256;
            var HashAlgorithm = "SHA512";
            var saltKey = "Luna121";

            byte[] initialVectorBytes = Encoding.ASCII.GetBytes(IV);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltKey);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Key, saltValueBytes, HashAlgorithm, PasswordIterations);
            byte[] KeyBytes = DerivedPassword.GetBytes(KeySize / 8);
            RijndaelManaged SymmetricKey = new RijndaelManaged();
            SymmetricKey.Mode = CipherMode.CBC;
            byte[] CipherTextBytes = null;
            using (ICryptoTransform Encryptor = SymmetricKey.CreateEncryptor(KeyBytes, initialVectorBytes))
            {
                using (MemoryStream MemStream = new MemoryStream())
                {
                    using (CryptoStream CryptoStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                    {
                        CryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        CryptoStream.FlushFinalBlock();
                        CipherTextBytes = MemStream.ToArray();
                        MemStream.Close();
                        CryptoStream.Close();
                    }
                }
            }
            SymmetricKey.Clear();
            return Convert.ToBase64String(CipherTextBytes);
        }

        public static string Decrypt(this string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return "";

            int passwordIterations = 2;
            int keySize = 256;
            var hashAlgorithm = "SHA512";
            var saltKey = "Luna121";

            byte[] initialVectorBytes = Encoding.ASCII.GetBytes(IV);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltKey);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes DerivedPassword = new PasswordDeriveBytes(Key, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] KeyBytes = DerivedPassword.GetBytes(keySize / 8);
            RijndaelManaged SymmetricKey = new RijndaelManaged();
            SymmetricKey.Mode = CipherMode.CBC;
            byte[] PlainTextBytes = new byte[cipherTextBytes.Length];
            int ByteCount = 0;
            using (ICryptoTransform Decryptor = SymmetricKey.CreateDecryptor(KeyBytes, initialVectorBytes))
            {
                using (MemoryStream MemStream = new MemoryStream(cipherTextBytes))
                {
                    using (CryptoStream CryptoStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
                    {

                        ByteCount = CryptoStream.Read(PlainTextBytes, 0, PlainTextBytes.Length);
                        MemStream.Close();
                        CryptoStream.Close();
                    }
                }
            }
            SymmetricKey.Clear();
            return Encoding.UTF8.GetString(PlainTextBytes, 0, ByteCount);
        }
    }
}
