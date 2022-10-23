using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
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
            EvaluationForm();
        }

        public static bool IsAdmin;
        public static int IdEmployee;
        public static string CallTo;
        public static string connectionString;

        static void EvaluationForm()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);

            var BusinessInfos = new BusinessInfo();
            SqlCommand cmd1 = new SqlCommand("SELECT LicenseActual, ExpirationDate FROM BusinessInfo WHERE BusinessId ='" + 1 + "'", connection);
            connection.Close();
            connection.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                if (dr["LicenseActual"].GetType() != typeof(DBNull))
                    BusinessInfos.LicenseActual = dr.GetString(dr.GetOrdinal("LicenseActual"));
                if (dr["ExpirationDate"].GetType() != typeof(DBNull))
                    BusinessInfos.ExpirationDate = dr.GetDateTime(dr.GetOrdinal("ExpirationDate"));

                connection.Close();
                if (BusinessInfos.ExpirationDate.HasValue && BusinessInfos.ExpirationDate < DateTime.Today)
                {
                    if (MessageBox.Show("¿Desea para renovar su suscripcion? \n\n Su tiempo de prueba ha expirado, si no tiene el numero de licencia necesario para renovar favor ponerse en contacto con su proveedor.", "FastFood", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        RenewLicense.Instance = new RenewLicense();
                        RenewLicense.Instance.business = BusinessInfos;
                        RenewLicense.Instance.licenceActual = BusinessInfos.LicenseActual;
                        RenewLicense.Instance.Show();
                        Application.Run(RenewLicense.Instance);
                        return;
                    }
                }
            }

            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS UserCount FROM Users", connection);
            connection.Close();
            connection.Open();
            SqlDataReader dr1 = cmd.ExecuteReader();
            if (dr1.Read())
            {
                var count = dr1.GetInt32(dr1.GetOrdinal("UserCount"));
                var existsUser = count > 0;
                connection.Close();
                if (!existsUser)
                {
                    var first = new FirtsRegisterForm();
                    first.Show();
                    Application.Run(first);
                    return;
                }
            }

            Application.Run(new LoginForm());
            return;
        }
    }
}
