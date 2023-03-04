using Microsoft.Data.SqlClient;
using System;

namespace FastFood.Infrastructure.Utils
{
    public class Backup
    {
        public static bool MakeBackup(string ubicacion, string strConnection, string dbName)
        {
            string nombre = dbName + "_" + DateTime.Now.Year.ToString() + "_"
                + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + "_"
                + DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_"
                + DateTime.Now.Second.ToString() + ".bak";

            var con = new SqlConnection(strConnection);
            var cmd = new SqlCommand("BACKUP DATABASE "+ dbName + " TO DISK='" + ubicacion +"/"+ nombre + "'", con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
                con.Close();
                return false;
            }
        }

        public static bool RestoreBackup(string archivo, string strConnection)
        {
            var con = new SqlConnection(strConnection);
            var cmd = new SqlCommand("RESTORE DATABASE AppointmentSystemMedical FROM DISK='" + archivo + "'", con);

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
