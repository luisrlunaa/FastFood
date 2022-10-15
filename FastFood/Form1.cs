using FastFood.Infrastructure.DataAccess.Repositories;
using Models.ViewModels.GenericLists;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class Form1 : Form
    {
        BusinessRepository businessRepository = new BusinessRepository();

        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var (business, message1) = businessRepository.GetBusinessInfo(1);
            if (business == null)
                MessageBox.Show(message1);

            lblDir.Text = business.Address;
            lblLogo.Text = business.Name;
            lblTel1.Text = business.Phone1;
            lblTel2.Text = business.Phone2;
            lblRNC.Text = business.RNC;

            button7.Visible = false;
            mainpanel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = false;
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            loadform(new Form1());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = true;
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            GenericLists.startIndexProduct = 0;
            GenericLists.endIndexProduct = 0;
            loadform(new FoodListForm());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = true;
            SidePanel.Height = button3.Height;
            SidePanel.Top = button3.Top;
            GenericLists.startIndexProduct = 0;
            GenericLists.endIndexProduct = 0;
            loadform(new DrinkListForm());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SalesForm sales = new SalesForm();
            sales.lblSales.Text = "Delivery";
            sales.lblDir.Text = lblDir.Text;
            sales.lblLogo.Text = lblLogo.Text;
            sales.lblTel1.Text = lblTel1.Text;
            sales.lblTel2.Text = lblTel2.Text;
            sales.lblRNC.Text = lblRNC.Text;
            sales.lblSales.ForeColor = Color.Black;
            sales.panelIdentify.BackColor = Color.CornflowerBlue;
            sales.lblDireccion.Visible = true;
            sales.txtDireccion.Visible = true;
            sales.lblDelivery.Visible = true;
            sales.txtDelivery.Visible = true;
            sales.lblDAmount.Visible = true;
            sales.txtDAmount.Visible = true;
            mainpanel.Visible = true;
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;

            loadform(sales);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManagerProductForm form = new ManagerProductForm();
            SidePanel.Height = button5.Height;
            SidePanel.Top = button5.Top;
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SalesForm sales = new SalesForm();
            sales.lblSales.Text = "Ventas";
            sales.lblDir.Text = lblDir.Text;
            sales.lblLogo.Text = lblLogo.Text;
            sales.lblTel1.Text = lblTel1.Text;
            sales.lblTel2.Text = lblTel2.Text;
            sales.lblRNC.Text = lblRNC.Text;
            sales.lblSales.ForeColor = Color.Black;
            sales.panelIdentify.BackColor = Color.ForestGreen;
            mainpanel.Visible = true;
            SidePanel.Height = button6.Height;
            SidePanel.Top = button6.Top;

            loadform(sales);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = true;
            SidePanel.Height = button6.Height;
            SidePanel.Top = button6.Top;

            loadform(new BoxSquareForm());
            Program.IdEmployee = 0;
        }

        private void btnListSales_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = true;
            SidePanel.Height = btnListSales.Height;
            SidePanel.Top = btnListSales.Top;

            loadform(new SalesListForm());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = true;
            loadform(new ConfigurationsForm());
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
