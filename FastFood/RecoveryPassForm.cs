using FastFood.Infrastructure.DataAccess.Repositories;
using FastFoodDemo.Utils;
using System;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class RecoveryPassForm : Form
    {
        EmployeesRepository employeesRepository = new EmployeesRepository();
        public RecoveryPassForm()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            if (btnIngresar.Text == "Verificar")
            {
                var (employee, message1) = employeesRepository.GetEmployeeByDocumentNo(txtdocNo.Text);
                if (message1.Contains("Error"))
                    MessageBox.Show(message1);

                if (employee is null)
                {
                    MessageBox.Show("Empleado no encotrado, consulte con su administrador de sistema.");
                    return;
                }

                panel1.Visible = false;

                btnIngresar.Text = "Resetear";
                Program.IdEmployee = employee.IdEmp;
                return;
            }

            if (btnIngresar.Text == "Resetear")
            {
                var (user, message1) = employeesRepository.GetUserByEmployeeId(Program.IdEmployee);
                if (message1.Contains("Error"))
                    MessageBox.Show(message1);

                user.Password = txtpass2.Text.Encrypt();
                user.LastUpdate = DateTime.Today;
                var (saved, message) = employeesRepository.UpdateUser(user);
                if (saved)
                {
                    panel1.Visible = true;
                    btnIngresar.Text = "Verificar";
                    MessageBox.Show(message);
                    var login = new LoginForm();
                    login.Show();
                    Close();
                    return;
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();
            Close();
        }
    }
}
