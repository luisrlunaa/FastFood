using FastFood.FastFood.Infrastructure.Constants;
using FastFood.Infrastructure.DataAccess.Repositories;
using FastFoodDemo.Utils;
using System;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class LoginForm : Form
    {
        EmployeesRepository employeesRepository = new EmployeesRepository();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var password = txtPassword.Text.Encrypt();
            var (users, message) = employeesRepository.GetUserByUserNameAndPassword(txtUser.Text, password);
            if (message.Contains("Error"))
                MessageBox.Show(message);

            if (users is null || users.IdEmp == 0)
            {
                MessageBox.Show("Las Credenciales no Concuerdan, verifique su nombre de usuario y contraseña e intente nuevamente.");
                return;
            }

            Program.IdEmployee = users.IdEmp;
            var (employee, message1) = employeesRepository.GetEmployeeById(users.IdEmp);
            if (message1.Contains("Error"))
                MessageBox.Show(message1);

            if (employee is null || employee.IdEmp == 0)
            {
                MessageBox.Show("Empleado no encotrado, consulte con su administrador de sistema.");
                return;
            }

            Program.IsAdmin = employee.EmployeeType.ToLower() == EmployeeTypeConstants.Admin.ToLower();

            if (employee != null)
            {
                Form1 menu = new Form1();
                menu.Show();
                Hide();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var recovery = new RecoveryPassForm();
            recovery.Show();
            Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!System.IO.Directory.Exists(@"C:\\Img\\"))
            {
                System.IO.Directory.CreateDirectory(@"C:\\Img\\");
            }
        }
    }
}
