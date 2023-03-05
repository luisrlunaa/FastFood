using Microsoft.Data.SqlClient;
using System;

namespace FastFood.Infrastructure.Utils
{
    public class Backup
    {
        public static (bool success, string filename) MakeBackup(string ubicacion, string strConnection, string dbName)
        {
            string nombre = "_" + dbName + "_" + DateTime.Now.ToShortDateString().Replace("/","-") + ".bak";

            var con = new SqlConnection(strConnection);
            var cmd = new SqlCommand("BACKUP DATABASE "+ dbName + " TO DISK='" + ubicacion +"/"+ nombre + "'", con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return (true, nombre);
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                con.Close();
                return (false, string.Empty);
            }
        }

        public static bool RestoreBackup(string ubicacion, string strConnection, string dbName)
        {
            var con = new SqlConnection(strConnection);
            var cmd = new SqlCommand("RESTORE DATABASE "+ dbName + " FROM DISK='" + ubicacion + "'", con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                con.Close();
                return false;
            }
        }
    }
}
