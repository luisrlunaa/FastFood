using System;
using System.Windows.Forms;

namespace FastFoodDemo
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        //Business Information
        public static string BusinessName;
        public static string BusinessAddress;
        public static string BusinessPhone1;
        public static string BusinessPhone2;
        public static string BusinessRnc;

        //Sales Information
        public static string SaleId;
        public static string ClientName;
        public static string SaleAddress;
        public static string DateIn;
        public static string TypeNCF;
        public static string NCF;
        public static string SalesCheckType;
        public static string Delivery;
        public static string DeliveryAmount;
        public static bool HasNCF;
        public static string SubTotal;
        public static string IgvTotal;
        public static string Total;
    }
}
