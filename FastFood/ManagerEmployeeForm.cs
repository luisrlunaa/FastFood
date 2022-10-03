using FastFood.FastFood.Infrastructure.Constants;
using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using FastFoodDemo.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class ManagerEmployeeForm : Form
    {
        EmployeesRepository employeesRepository = new EmployeesRepository();
        public bool isEdit = false;
        public ManagerEmployeeForm()
        {
            InitializeComponent();
        }

        private void data_employee_Click(object sender, System.EventArgs e)
        {
            lblIdEmployee.Text = data_employee.CurrentRow.Cells[0].Value.ToString();
            if (!string.IsNullOrWhiteSpace(lblIdEmployee.Text) && Convert.ToInt32(lblIdEmployee.Text) > 0)
            {
                btnNewEmployee.Visible = false;
                btnNewUser.Visible = false;
                btnEditEmployee.Visible = true;
                btnEditUser.Visible = true;
            }
        }

        private void btnEditEmployee_Click(object sender, System.EventArgs e)
        {
            isEdit = true;
            btnEditEmployee.Visible = false;
            btnEditUser.Visible = false;
            btnNewEmployee.Visible = true;
            btnNewUser.Visible = true;
            panelUser.Visible = false;
            panelEmployee.Visible = true;

            cbxIDType.Items.Clear();
            cbxIDType.Items.Add(IDTypeConstants.ID);
            cbxIDType.Items.Add(IDTypeConstants.PassPort);

            cbxEmpType.Items.Clear();
            cbxEmpType.Items.Add(EmployeeTypeConstants.Admin);
            cbxEmpType.Items.Add(EmployeeTypeConstants.Employee);

            var (employee, message) = employeesRepository.GetEmployeeById(Convert.ToInt32(lblIdEmployee.Text));
            txtNameE.Text = employee.FirstName;
            txtLastNameE.Text = employee.LastName;
            txtIdE.Text = employee.DocumentNo;
            cbxIDType.SelectedIndex = cbxIDType.Items.IndexOf(employee.DocumentType);
            cbxEmpType.SelectedIndex = cbxEmpType.Items.IndexOf(employee.EmployeeType);
            lblUserId.Text = employee.IdUser.HasValue ? employee.IdUser.Value.ToString() : 0.ToString();
            lblPass.Text = string.Empty;
        }

        private void btnEditUser_Click(object sender, System.EventArgs e)
        {
            isEdit = true;
            btnEditEmployee.Visible = false;
            btnEditUser.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            btnNewEmployee.Visible = true;
            btnNewUser.Visible = true;
            panelUser.Visible = true;
            panelEmployee.Visible = false;

            var (user, message) = employeesRepository.GetUserByEmployeeId(Convert.ToInt32(lblIdEmployee.Text));
            lblPass.Text = user.Password;
            lblUserName.Text = user.UserName;

            if (!Program.IsAdmin)
            {
                btnAllowedEdituser.Visible = true;
                lblClave.Visible = false;
                lblClave2.Visible = false;
                txtPass.Visible = false;
                txtPass2.Visible = false;
            }
            else
            {
                lblClave.Visible = true;
                lblClave2.Visible = true;
                txtPass.Visible = true;
                txtPass2.Visible = true;
            }
        }

        private void btnAllowedEdituser_Click(object sender, EventArgs e)
        {
            if (lblPass.Text == txtActualPass.Text.Encrypt())
            {
                lblClave.Visible = true;
                lblClave2.Visible = true;
                txtPass.Visible = true;
                txtPass2.Visible = true;
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                if (!string.IsNullOrWhiteSpace(lblPass.Text))
                {
                    if (txtPass2.Text != txtPass.Text)
                    {
                        MessageBox.Show("Las claves no coinciden, asegurece que la clave y la confirmacion sean las mismas");
                        return;
                    }

                    var user = new Users()
                    {
                        UserName = lblUserName.Text,
                        IdEmp = Convert.ToInt32(lblIdEmployee.Text),
                        Password = txtPass2.Text.Encrypt(),
                        LastUpdate = DateTime.Today
                    };

                    var (result, message) = employeesRepository.UpdateUser(user);
                    MessageBox.Show(message);

                    txtActualPass.Text = string.Empty;
                    txtPass.Text = string.Empty;
                    txtPass2.Text = string.Empty;
                }
                else
                {
                    var employee = new Employee()
                    {
                        FirstName = txtNameE.Text,
                        LastName = txtLastNameE.Text,
                        IdUser = string.IsNullOrWhiteSpace(lblUserId.Text) ? 0 : Convert.ToInt32(lblUserId.Text),
                        DocumentNo = txtIdE.Text,
                        DocumentType = cbxIDType.Text,
                        EmployeeType = cbxEmpType.Text,
                        LastUpdate = DateTime.Today
                    };

                    var (result, message) = employeesRepository.UpdateEmployee(employee, Program.IsAdmin);
                    MessageBox.Show(message);
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(lblPass.Text))
                {
                    if (txtPass2.Text != txtPass.Text)
                    {
                        MessageBox.Show("Las claves no coinciden, asegurece que la clave y la confirmacion sean las mismas");
                        return;
                    }

                    var user = new Users()
                    {
                        UserName = txtActualPass.Text,
                        IdEmp = Convert.ToInt32(lblIdEmployee.Text),
                        Password = txtPass2.Text.Encrypt(),
                        DateIn = DateTime.Today
                    };

                    var (result, message) = employeesRepository.UpdateUser(user);
                    MessageBox.Show(message);
                }
                else
                {
                    var employee = new Employee()
                    {
                        FirstName = txtNameE.Text,
                        LastName = txtLastNameE.Text,
                        IdUser = string.IsNullOrWhiteSpace(lblUserId.Text) ? 0 : Convert.ToInt32(lblUserId.Text),
                        DocumentNo = txtIdE.Text,
                        DocumentType = cbxIDType.Text,
                        EmployeeType = cbxEmpType.Text,
                        DateIn = DateTime.Today
                    };

                    var (result, message) = employeesRepository.AddEmployee(employee);
                    MessageBox.Show(message);
                }
            }
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            isEdit = false;
            btnEditEmployee.Visible = false;
            btnEditUser.Visible = false;
            panelUser.Visible = false;
            panelEmployee.Visible = true;

            cbxIDType.Items.Clear();
            cbxIDType.Items.Add(IDTypeConstants.ID);
            cbxIDType.Items.Add(IDTypeConstants.PassPort);

            cbxEmpType.Items.Clear();
            cbxEmpType.Items.Add(EmployeeTypeConstants.Admin);
            cbxEmpType.Items.Add(EmployeeTypeConstants.Employee);

            txtNameE.Text = string.Empty;
            txtLastNameE.Text = string.Empty;
            txtIdE.Text = string.Empty;
            lblUserId.Text = string.Empty;
            lblPass.Text = string.Empty;
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            lblActualPass.Text = "Usuario";
            lblUserName.Visible = false;
            isEdit = false;
            btnEditEmployee.Visible = false;
            btnEditUser.Visible = false;
            panelUser.Visible = true;
            panelEmployee.Visible = false;
        }

        public void LoadEmployee()
        {
            var lst = new List<Employee>();
            if (Program.IsAdmin)
            {
                var (list, message) = employeesRepository.GetEmployees();
                if (message.Contains("Error"))
                    MessageBox.Show(message);

                lst = list;
            }
            else
            {
                var (employee, message) = employeesRepository.GetEmployeeById(Program.IdEmployee);
                if (message.Contains("Error"))
                    MessageBox.Show(message);

                lst.Add(employee);
            }


            if (lst != null)
            {
                data_employee.Rows.Clear();
                for (int i = 0; i < lst.Count; i++)
                {
                    data_employee.Rows.Add();
                    data_employee.Rows[i].Cells["id_employee"].Value = lst[i].IdEmp;
                    data_employee.Rows[i].Cells["employeeName"].Value = lst[i].FirstName + " " + lst[i].LastName;
                }
            }
        }

        private void data_employee_DoubleClick(object sender, EventArgs e)
        {
            if (Program.IsAdmin)
            {
                button1.Visible = true;
                button2.Visible = true;
                btnEditEmployee.Visible = false;
                btnEditUser.Visible = false;
                btnNewEmployee.Visible = false;
                btnNewUser.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro desea Eliminar este Usuario?", "FoodShop", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                var (user, message) = employeesRepository.DeleteUser(Convert.ToInt32(lblIdEmployee.Text));
                MessageBox.Show(message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro desea Eliminar este Empleado?", "FoodShop", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                var (user, message) = employeesRepository.DeleteEmployee(Convert.ToInt32(lblIdEmployee.Text));
                MessageBox.Show(message);
            }
        }

        private void ManagerEmployeeForm_Load(object sender, EventArgs e)
        {
            if (!Program.IsAdmin)
            {
                button1.Visible = false;
                button2.Visible = false;
                btnEditEmployee.Visible = false;
                btnEditUser.Visible = false;
                btnNewEmployee.Visible = false;
                btnNewUser.Visible = false;
            }

            LoadEmployee();
        }
    }
}
