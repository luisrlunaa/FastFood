using FastFood.FastFood.Infrastructure.Constants;
using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using FastFoodDemo.Utils;
using System;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class LoginForm : Form
    {
        BusinessRepository businessRepository = new BusinessRepository();
        EmployeesRepository employeesRepository = new EmployeesRepository();
        public SystemColor systemColor;
        public BusinessInfo businessInfo;
        public bool AllowLogin = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!AllowLogin)
            {
                MessageBox.Show("No tiene permisos para ingresar al sistema favor ponerse en contacto con su proveedor.");
                return;
            }

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
                Form1.Instance = new Form1();
                Form1.Instance.business = businessInfo;
                Form1.Instance.systemColor = systemColor;
                Form1.Instance.lblDir.Text = businessInfo.Address;
                Form1.Instance.lblLogo.Text = businessInfo.Name;
                Form1.Instance.lblTel1.Text = businessInfo.Phone1;
                Form1.Instance.lblTel2.Text = businessInfo.Phone2;
                Form1.Instance.lblRNC.Text = businessInfo.RNC;

                SalesForm.Instance = new SalesForm();
                SalesForm.Instance.PrintName = businessInfo.PrinterName;
                Form1.Instance.Show();
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
            var (business, message1) = businessRepository.GetBusinessInfo(1);
            if (business == null)
                MessageBox.Show(message1);

            if ((!business.ExpirationDate.HasValue || business.ExpirationDate == null || business.ExpirationDate == DateTime.MinValue) && string.IsNullOrWhiteSpace(business.LicenseActual))
            {
                if (MessageBox.Show("¿Desea Activar el Servicio de Prueba?", "FastFood", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    business.ExpirationDate = DateTime.Today.AddDays(15);
                    var (update, message) = businessRepository.UpdateBusinessInfo(business);
                    if (message.Contains("Error"))
                        MessageBox.Show(message);

                    if (!update)
                    {
                        MessageBox.Show("Hubo un problema al activar el servicio de prueba favor ponerse en contacto con su proveedor.");
                        AllowLogin = false;
                        return;
                    }

                    AllowLogin = true;
                    MessageBox.Show("Servicio de Prueba Activado, Podra utilizar el sistema de manera gratuita durante 15 dias apartir del dia de hoy");
                }
                else {
                    AllowLogin = false;
                }
            }
            else if (business.ExpirationDate.HasValue && business.ExpirationDate > DateTime.Today)
            {
                AllowLogin = true;
            }
            else
            {
                AllowLogin = false;
                if (MessageBox.Show("¿Desea para renovar su suscripcion? \n\n Su tiempo de prueba ha expirado, si no tiene el numero de licencia necesario para renovar favor ponerse en contacto con su proveedor.", "FastFood", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    RenewLicense.Instance = new RenewLicense();
                    RenewLicense.Instance.business = business;
                    RenewLicense.Instance.licenceActual = business.LicenseActual;
                    RenewLicense.Instance.isFromLogin = true;
                    RenewLicense.Instance.Show();
                }
                return;
            }

            if (AllowLogin)
            {
                if (!System.IO.Directory.Exists(@"C:\\Img\\"))
                {
                    System.IO.Directory.CreateDirectory(@"C:\\Img\\");
                }

                Form1.Instance = new Form1();
                businessInfo = new BusinessInfo();
                businessInfo = business;
                Form1.Instance.systemColor = new SystemColor();
                systemColor = string.IsNullOrWhiteSpace(business.SystemColor) 
                            ? JsonSerializer.Deserialize<SystemColor>(business.DefaultSystemColor) 
                            : JsonSerializer.Deserialize<SystemColor>(business.SystemColor);

                if (systemColor != null && systemColor.ButtonsColor != null)
                {
                    LoginForm login = new LoginForm();
                    login.groupBox1.BackColor = Color.FromName(systemColor.BackgroundPrimaryWindows);
                    login.btnIngresar.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                }

                var (existsUser, message) = employeesRepository.GetExistsUser();
                if (message.Contains("Error"))
                    MessageBox.Show(message);

                if (!existsUser)
                {
                    var first = new FirtsRegisterForm();
                    first.Show();
                }
            }
        }
    }
}
