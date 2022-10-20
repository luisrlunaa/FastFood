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
            Application.Run(new LoginForm());
        }

        public static bool IsAdmin;
        public static int IdEmployee;
        public static string CallTo;
    }
}
