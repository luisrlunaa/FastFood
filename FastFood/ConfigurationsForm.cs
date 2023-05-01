using FastFood.Infrastructure.Constants;
using FastFood.Models.Entities;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FastFood.Infrastructure.Utils;

namespace FastFoodDemo
{
    public partial class ConfigurationsForm : Form
    {
        public SystemColor systemColor;
        public string BusinessAccess;
        public static ConfigurationsForm Instance;
        public ConfigurationsForm()
        {
            InitializeComponent();
            Instance = this;
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            NCFForm.Instance = new NCFForm();
            mainSubpanel.Visible = true;
            SideSubPanel.Height = button1.Height;
            SideSubPanel.Top = button1.Top;
            button1.BackColor = Color.Lavender;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;

            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                button1.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;

                NCFForm.Instance.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);

                NCFForm.Instance.btnAplicar.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                NCFForm.Instance.btnAplicar.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
            }

            loadform(NCFForm.Instance);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            ManagerEmployeeForm.Instance =new ManagerEmployeeForm();
            mainSubpanel.Visible = true;
            SideSubPanel.Height = button2.Height;
            SideSubPanel.Top = button2.Top;
            button1.BackColor = Color.White;
            button2.BackColor = Color.Lavender;
            button3.BackColor = Color.White;

            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                button1.BackColor = Color.White; 
                button2.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);
                button3.BackColor = Color.White; 
                
                ManagerEmployeeForm.Instance.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);

                ManagerEmployeeForm.Instance.btnNewEmployee.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                ManagerEmployeeForm.Instance.btnNewEmployee.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
                ManagerEmployeeForm.Instance.btnEditEmployee.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);
                ManagerEmployeeForm.Instance.btnEditEmployee.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);
                ManagerEmployeeForm.Instance.button2.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);
                ManagerEmployeeForm.Instance.button2.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);

                ManagerEmployeeForm.Instance.btnNewUser.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                ManagerEmployeeForm.Instance.btnNewUser.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
                ManagerEmployeeForm.Instance.btnEditUser.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);
                ManagerEmployeeForm.Instance.btnEditUser.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);
                ManagerEmployeeForm.Instance.button1.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);
                ManagerEmployeeForm.Instance.button1.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);

                ManagerEmployeeForm.Instance.btnSave.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                ManagerEmployeeForm.Instance.btnSave.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
            }

            loadform(ManagerEmployeeForm.Instance);
        }

        private void ConfigurationsForm_Load(object sender, System.EventArgs e)
        {
            var hasNCFAccess = Access(BusinessPermissName.NCF);
            var hasUsersAccess = Access(BusinessPermissName.Users);
            var hasStyleAccess = Access(BusinessPermissName.Style);

            mainSubpanel.Visible = true;
            button1.Enabled = hasNCFAccess; //Manejador de comprobantes
            button2.Enabled = hasUsersAccess; //Manejador de usuarios
            button3.Enabled = hasStyleAccess; //Estilos y colores

            NCFForm.Instance = new NCFForm();
            NCFForm.Instance.BusinessAccess = BusinessAccess;

            if (!Program.IsAdmin)
            {
                SideSubPanel.Height = button2.Height;
                SideSubPanel.Top = button2.Top;
                button2.BackColor = Color.Lavender;
                button1.Enabled = false;
                button3.Enabled = false;

                if (systemColor != null && systemColor.ButtonsColor != null)
                {
                    button1.Enabled = false;
                    button2.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);
                    button3.Enabled = false;
                }

                ManagerEmployeeForm.Instance = new ManagerEmployeeForm();
                if (systemColor != null && systemColor.ButtonsColor != null)
                {
                    button1.BackColor = Color.White;
                    button2.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);
                    button3.BackColor = Color.White;

                    ManagerEmployeeForm.Instance.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);

                    ManagerEmployeeForm.Instance.btnNewEmployee.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                    ManagerEmployeeForm.Instance.btnNewEmployee.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
                    ManagerEmployeeForm.Instance.btnEditEmployee.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);
                    ManagerEmployeeForm.Instance.btnEditEmployee.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);
                    ManagerEmployeeForm.Instance.button2.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);
                    ManagerEmployeeForm.Instance.button2.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);

                    ManagerEmployeeForm.Instance.btnNewUser.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                    ManagerEmployeeForm.Instance.btnNewUser.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
                    ManagerEmployeeForm.Instance.btnEditUser.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);
                    ManagerEmployeeForm.Instance.btnEditUser.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);
                    ManagerEmployeeForm.Instance.button1.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);
                    ManagerEmployeeForm.Instance.button1.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);

                    ManagerEmployeeForm.Instance.btnSave.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                    ManagerEmployeeForm.Instance.btnSave.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
                }

                loadform(ManagerEmployeeForm.Instance);
            }
            else
            {
                SideSubPanel.Height = button1.Height;
                SideSubPanel.Top = button1.Top;
                button1.BackColor = Color.Lavender;
                button2.BackColor = Color.White;
                button3.BackColor = Color.White;

                if (systemColor != null && systemColor.ButtonsColor != null)
                {
                    button1.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);
                    button2.BackColor = Color.White;
                    button3.BackColor = Color.White;
                }

                if (systemColor != null && systemColor.ButtonsColor != null)
                {
                    button1.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);
                    button2.BackColor = Color.White;
                    button3.BackColor = Color.White;

                    NCFForm.Instance.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);

                    NCFForm.Instance.btnAplicar.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                    NCFForm.Instance.btnAplicar.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
                }

                loadform(NCFForm.Instance);
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            StyleForm.Instance = new StyleForm();
            mainSubpanel.Visible = true;
            SideSubPanel.Height = button3.Height;
            SideSubPanel.Top = button3.Top;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button3.BackColor = Color.Lavender;

            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                button1.BackColor = Color.White;
                button2.BackColor = Color.White;
                button3.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);

                StyleForm.Instance.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);

                StyleForm.Instance.btnAplicar.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                StyleForm.Instance.btnAplicar.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
            }

            loadform(StyleForm.Instance);
        }

        public void loadform(object Form)
        {
            if (this.mainSubpanel.Controls.Count > 0)
                this.mainSubpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainSubpanel.Controls.Add(f);
            this.mainSubpanel.Tag = f;
            f.Show();
        }

        public bool Access(string accessName)
        {
            var businessAccess = string.IsNullOrWhiteSpace(BusinessAccess)
                               ? new List<string>()
                               : BusinessAccess.Split(',').ToList().CleanSpaceList();

            if (businessAccess != null && businessAccess.Any())
                return businessAccess.Contains(accessName);

            return false;
        }
    }
}
