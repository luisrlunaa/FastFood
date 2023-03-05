using FastFood.Models.Entities;
using Models.ViewModels.GenericLists;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class Form1 : Form
    {
        public SystemColor systemColor;
        public BusinessInfo business;
        public static Form1 Instance;
        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            Instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                Instance.panel1.BackColor = Color.FromArgb(41, 39, 40);
                Instance.panel2.BackColor = Color.FromName(systemColor.BackgroundHome);
                Instance.panel3.BackColor = Color.FromName(systemColor.BackgroundHome);
                Instance.lblLogo.ForeColor = Color.FromName(systemColor.BackgroundHome);
                Instance.SidePanel.BackColor = Color.FromName(systemColor.BackgroundHome);
                Instance.ForeColor = Color.FromName(systemColor.BackgroundHomeForeColor);
            }

            mainpanel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.Instance = new Form1();
            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                Instance.panel1.BackColor = Color.FromArgb(41, 39, 40);
                Instance.panel2.BackColor = Color.FromName(systemColor.BackgroundHome);
                Instance.panel3.BackColor = Color.FromName(systemColor.BackgroundHome);
                Instance.lblLogo.ForeColor = Color.FromName(systemColor.BackgroundHome);
                Instance.SidePanel.BackColor = Color.FromName(systemColor.BackgroundHome);
                Instance.ForeColor = Color.FromName(systemColor.BackgroundHomeForeColor);
            }

            mainpanel.Visible = false;
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;

            loadform(Form1.Instance);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FoodListForm.Instance = new FoodListForm();
            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                FoodListForm.Instance.BackColor = Color.FromName(systemColor.BackgroundPrimaryWindows);
                FoodListForm.Instance.ForeColor = Color.FromName(systemColor.BackgroundPrimaryWindowsForeColor);

                FoodListForm.Instance.button1.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonDanger);
                FoodListForm.Instance.button2.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);

                FoodListForm.Instance.button1.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonDangerForeColor);
                FoodListForm.Instance.button2.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);

                FoodListForm.Instance.panel1.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
                FoodListForm.Instance.panel2.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
                FoodListForm.Instance.panel3.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
                FoodListForm.Instance.panel4.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
                FoodListForm.Instance.panel5.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
                FoodListForm.Instance.panel6.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);

                FoodListForm.Instance.panel1.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);
                FoodListForm.Instance.panel2.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);
                FoodListForm.Instance.panel3.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);
                FoodListForm.Instance.panel4.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);
                FoodListForm.Instance.panel5.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);
                FoodListForm.Instance.panel6.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);

                FoodListForm.Instance.btnAgregar1.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                FoodListForm.Instance.btnAgregar2.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                FoodListForm.Instance.btnAgregar3.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                FoodListForm.Instance.btnAgregar4.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                FoodListForm.Instance.btnAgregar5.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                FoodListForm.Instance.btnAgregar6.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);

                FoodListForm.Instance.btnAgregar1.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                FoodListForm.Instance.btnAgregar2.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                FoodListForm.Instance.btnAgregar3.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                FoodListForm.Instance.btnAgregar4.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                FoodListForm.Instance.btnAgregar5.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                FoodListForm.Instance.btnAgregar6.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);

                FoodListForm.Instance.btnSearch.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundary);
                FoodListForm.Instance.btnBack.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundary);
                FoodListForm.Instance.btnNext.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundary);

                FoodListForm.Instance.btnSearch.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundaryForeColor);
                FoodListForm.Instance.btnBack.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundaryForeColor);
                FoodListForm.Instance.btnNext.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundaryForeColor);
            }

            mainpanel.Visible = true;
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            GenericLists.startIndexProduct = 0;
            GenericLists.endIndexProduct = 0;

            loadform(FoodListForm.Instance);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DrinkListForm.Instance = new DrinkListForm();
            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                DrinkListForm.Instance.BackColor = Color.FromName(systemColor.BackgroundPrimaryWindows);
                DrinkListForm.Instance.ForeColor = Color.FromName(systemColor.BackgroundPrimaryWindowsForeColor);

                DrinkListForm.Instance.button1.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonDanger);
                DrinkListForm.Instance.button2.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);

                DrinkListForm.Instance.button1.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonDangerForeColor);
                DrinkListForm.Instance.button2.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
            
                DrinkListForm.Instance.panel1.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
                DrinkListForm.Instance.panel2.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
                DrinkListForm.Instance.panel3.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
                DrinkListForm.Instance.panel4.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
                DrinkListForm.Instance.panel5.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
                DrinkListForm.Instance.panel6.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
              
                DrinkListForm.Instance.panel1.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);
                DrinkListForm.Instance.panel2.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);
                DrinkListForm.Instance.panel3.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);
                DrinkListForm.Instance.panel4.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);
                DrinkListForm.Instance.panel5.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);
                DrinkListForm.Instance.panel6.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);
               
                DrinkListForm.Instance.btnAgregar1.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                DrinkListForm.Instance.btnAgregar2.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                DrinkListForm.Instance.btnAgregar3.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                DrinkListForm.Instance.btnAgregar4.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                DrinkListForm.Instance.btnAgregar5.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                DrinkListForm.Instance.btnAgregar6.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
               
                DrinkListForm.Instance.btnAgregar1.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                DrinkListForm.Instance.btnAgregar2.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                DrinkListForm.Instance.btnAgregar3.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                DrinkListForm.Instance.btnAgregar4.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                DrinkListForm.Instance.btnAgregar5.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                DrinkListForm.Instance.btnAgregar6.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
               
                DrinkListForm.Instance.btnSearch.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundary);
                DrinkListForm.Instance.btnBack.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundary);
                DrinkListForm.Instance.btnNext.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundary);
             
                DrinkListForm.Instance.btnSearch.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundaryForeColor);
                DrinkListForm.Instance.btnBack.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundaryForeColor);
                DrinkListForm.Instance.btnNext.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundaryForeColor);
            }

            mainpanel.Visible = true;
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
            GenericLists.startIndexProduct = 0;
            GenericLists.endIndexProduct = 0;

            loadform(DrinkListForm.Instance);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SalesForm.Instance = new SalesForm();
            SalesForm.Instance.lblSales.Text = "Delivery";
            SalesForm.Instance.lblDir.Text = lblDir.Text;
            SalesForm.Instance.lblLogo.Text = lblLogo.Text;
            SalesForm.Instance.lblTel1.Text = lblTel1.Text;
            SalesForm.Instance.lblTel2.Text = lblTel2.Text;
            SalesForm.Instance.lblRNC.Text = lblRNC.Text;
            SalesForm.Instance.lblSales.ForeColor = Color.Black;
            SalesForm.Instance.panelIdentify.BackColor = Color.CornflowerBlue;
            SalesForm.Instance.lblDireccion.Visible = true;
            SalesForm.Instance.txtDireccion.Visible = true;
            SalesForm.Instance.lblDelivery.Visible = true;
            SalesForm.Instance.txtDelivery.Visible = true;
            SalesForm.Instance.lblDAmount.Visible = true;
            SalesForm.Instance.txtDAmount.Visible = true;

            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                SalesForm.Instance.BackColor = Color.FromName(systemColor.BackgroundPrimaryWindows);
                SalesForm.Instance.ForeColor = Color.FromName(systemColor.BackgroundPrimaryWindowsForeColor);

                SalesForm.Instance.panel1.BackColor = Color.FromName(systemColor.BackgroundHome);
                SalesForm.Instance.panel2.BackColor = Color.FromName(systemColor.BackgroundHome);
                SalesForm.Instance.lblLogo.ForeColor = Color.FromName(systemColor.BackgroundHome);

                SalesForm.Instance.btnBorrar.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonDanger);
                SalesForm.Instance.btnEnviar.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                SalesForm.Instance.btnVender.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);

                SalesForm.Instance.btnBorrar.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonDangerForeColor);
                SalesForm.Instance.btnEnviar.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
                SalesForm.Instance.btnVender.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);
            }

            mainpanel.Visible = true;
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;

            loadform(SalesForm.Instance);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManagerProductForm.Instance = new ManagerProductForm();
            SidePanel.Height = button5.Height;
            SidePanel.Top = button5.Top;

            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                ManagerProductForm.Instance.BackColor = Color.FromName(systemColor.BackgroundPrimaryWindows);

                ManagerProductForm.Instance.btnGuardar.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                ManagerProductForm.Instance.button1.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);
            }

            ManagerProductForm.Instance.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SalesForm.Instance = new SalesForm();
            SalesForm.Instance.lblSales.Text = "Ventas";
            SalesForm.Instance.lblDir.Text = lblDir.Text;
            SalesForm.Instance.lblLogo.Text = lblLogo.Text;
            SalesForm.Instance.lblTel1.Text = lblTel1.Text;
            SalesForm.Instance.lblTel2.Text = lblTel2.Text;
            SalesForm.Instance.lblRNC.Text = lblRNC.Text;
            SalesForm.Instance.lblSales.ForeColor = Color.Black;
            SalesForm.Instance.panelIdentify.BackColor = Color.ForestGreen;

            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                SalesForm.Instance.BackColor = Color.FromName(systemColor.BackgroundPrimaryWindows);

                SalesForm.Instance.BackColor = Color.FromName(systemColor.BackgroundPrimaryWindows);

                SalesForm.Instance.lblSales.ForeColor = Color.FromName(systemColor.BackgroundPrimaryWindowsForeColor);

                SalesForm.Instance.panel1.BackColor = Color.FromName(systemColor.BackgroundHome);
                SalesForm.Instance.panel2.BackColor = Color.FromName(systemColor.BackgroundHome);

                SalesForm.Instance.lblLogo.ForeColor = Color.FromName(systemColor.BackgroundHome);

                SalesForm.Instance.btnBorrar.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonDanger);
                SalesForm.Instance.btnEnviar.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                SalesForm.Instance.btnVender.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);

                SalesForm.Instance.btnBorrar.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonDangerForeColor);
                SalesForm.Instance.btnEnviar.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
                SalesForm.Instance.btnVender.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);
            }

            mainpanel.Visible = true;
            SidePanel.Height = button6.Height;
            SidePanel.Top = button6.Top;

            loadform(SalesForm.Instance);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            BoxSquareForm.Instance = new BoxSquareForm();
            BoxSquareForm.Instance.windowsUserName = business.WindowsUserName;
            BoxSquareForm.Instance.sqlFolderName = business.SqlFolderName;
            BoxSquareForm.Instance.lblDir.Text = lblDir.Text;
            BoxSquareForm.Instance.lblLogo.Text = lblLogo.Text;

            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                BoxSquareForm.Instance.BackColor = Color.FromName(systemColor.BackgroundPrimaryWindows);
                BoxSquareForm.Instance.ForeColor = Color.FromName(systemColor.BackgroundPrimaryWindowsForeColor);

                BoxSquareForm.Instance.btnregistrar.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccess);
                BoxSquareForm.Instance.btnimprimir.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                BoxSquareForm.Instance.btnsuma.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);
                BoxSquareForm.Instance.btnSearch.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundary);

                BoxSquareForm.Instance.btnregistrar.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSuccessForeColor);
                BoxSquareForm.Instance.btnimprimir.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                BoxSquareForm.Instance.btnsuma.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);
                BoxSquareForm.Instance.btnSearch.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundaryForeColor);
            }

            mainpanel.Visible = true;
            SidePanel.Height = button6.Height;
            SidePanel.Top = button6.Top;

            loadform(BoxSquareForm.Instance);
        }

        private void btnListSales_Click(object sender, EventArgs e)
        {
            SalesListForm.Instance = new SalesListForm();
            SalesListForm.Instance.lblDir.Text = lblDir.Text;
            SalesListForm.Instance.lblLogo.Text = lblLogo.Text;

            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                SalesListForm.Instance.BackColor = Color.FromName(systemColor.BackgroundPrimaryWindows);
                SalesListForm.Instance.ForeColor = Color.FromName(systemColor.BackgroundPrimaryWindowsForeColor);

                SalesListForm.Instance.btnSearch.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundary); 
                SalesListForm.Instance.btnPrint.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                SalesListForm.Instance.btnVender.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimary);

                SalesListForm.Instance.btnSearch.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundaryForeColor);
                SalesListForm.Instance.btnPrint.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                SalesListForm.Instance.btnVender.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonPrimaryForeColor);
            }

            mainpanel.Visible = true;
            SidePanel.Height = btnListSales.Height;
            SidePanel.Top = btnListSales.Top;

            loadform(SalesListForm.Instance);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ConfigurationsForm.Instance = new ConfigurationsForm();
            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                ConfigurationsForm.Instance.systemColor = new SystemColor();
                ConfigurationsForm.Instance.systemColor = systemColor;

                ConfigurationsForm.Instance.BackColor = Color.FromName(systemColor.BackgroundOthersWindows);
                ConfigurationsForm.Instance.ForeColor = Color.FromName(systemColor.BackgroundOthersWindowsForeColor);
            }

            mainpanel.Visible = true;

            loadform(ConfigurationsForm.Instance);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClientsForm.Instance = new ClientsForm();
            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                ClientsForm.Instance.BackColor = Color.FromName(systemColor.BackgroundPrimaryWindows);
                ClientsForm.Instance.ForeColor = Color.FromName(systemColor.BackgroundPrimaryWindowsForeColor);

                ClientsForm.Instance.panel3.BackColor = Color.FromName(systemColor.BackgroundSecondaryWindows);
                ClientsForm.Instance.panel3.ForeColor = Color.FromName(systemColor.BackgroundSecondaryWindowsForeColor);

                ClientsForm.Instance.btnAgregar3.BackColor = Color.FromName(systemColor.ButtonsColor.OtherButtons);
                ClientsForm.Instance.button1.BackColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundary);

                ClientsForm.Instance.btnAgregar3.ForeColor = Color.FromName(systemColor.ButtonsColor.OtherButtonsForeColor);
                ClientsForm.Instance.button1.ForeColor = Color.FromName(systemColor.ButtonsColor.ButtonSecundaryForeColor);
            }

            mainpanel.Visible = true;
            SidePanel.Height = button7.Height;
            SidePanel.Top = button7.Top;

            loadform(ClientsForm.Instance);
        }

        public void loadform(object Form)
        {
            if (this.mainpanel.Controls.Count > 0)
                this.mainpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }
    }
}
