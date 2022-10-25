using FastFood.FastFood.Infrastructure.Constants;
using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using FastFoodDemo.Utils;
using System;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class FirtsRegisterForm : Form
    {
        EmployeesRepository employeesRepository = new EmployeesRepository();
        public FirtsRegisterForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtpass2.Text)
            {
                MessageBox.Show("Las claves no coinciden, asegurece que la clave y la confirmacion sean las mismas");
                return;
            }

            if (string.IsNullOrEmpty(txtdocNo.Text))
            {
                if (MessageBox.Show("¿Desea autogenerar un numero identificacion para este Empleado?", "FoodShop", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    var id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 12);
                    txtdocNo.Text = id;
                }
            }

            var employee = new Employee()
            {
                FirstName = txtNameE.Text,
                LastName = txtLastNameE.Text,
                IdUser = null,
                DocumentNo = txtdocNo.Text,
                DocumentType = cbxIDType.Text,
                EmployeeType = EmployeeTypeConstants.Admin,
                DateIn = DateTime.Today
            };

            var (result, message) = employeesRepository.AddEmployee(employee);
            if (message.Contains("Error"))
                MessageBox.Show(message);

            if(result)
            {
                var (emp, ms) = employeesRepository.GetLastEmployee();
                if (ms.Contains("Error"))
                    MessageBox.Show(ms);

                var user = new Users()
                {
                    UserName = textBox1.Text,
                    IdEmp = emp != null ? emp.IdEmp : 1,
                    Password = txtPassword.Text.Encrypt(),
                    DateIn = DateTime.Today
                };

                var (result1, message1) = employeesRepository.AddUser(user);
                if (message1.Contains("Error"))
                    MessageBox.Show(message1);

                if(result1)
                {
                    var (us, ms1) = employeesRepository.GetLastUser();
                    if (ms1.Contains("Error"))
                        MessageBox.Show(ms1);

                    employee.IdEmp = us.IdEmp;
                    employee.IdUser = us.IdUser;
                    employee.LastUpdate = DateTime.Today;
                    var (res, mes) = employeesRepository.UpdateEmployee(employee, true);
                    MessageBox.Show(mes);

                    new LoginForm().Show();
                    Hide();
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();
            Close();
        }

        private void FirtsRegisterForm_Load(object sender, EventArgs e)
        {
            cbxIDType.Items.Clear();
            cbxIDType.Items.Add(IDTypeConstants.ID);
            cbxIDType.Items.Add(IDTypeConstants.PassPort);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
