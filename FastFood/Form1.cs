using Infrastructure.Constants;
using Infrastructure.DataAccess.Repositories;
using Models.ViewModels.GenericLists;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class Form1 : Form
    {
        ProductsRepository productsRepository = new ProductsRepository();
        BusinessRepository businessRepository = new BusinessRepository();

        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var (business, message1) = businessRepository.GetBusinessInfo();
            if (business == null)
                MessageBox.Show(message1);

            lblDir.Text = business.Address;
            lblLogo.Text = business.Name;
            lblTel1.Text = business.Phone1;
            lblTel2.Text = business.Phone2;
            lblRNC.Text = business.RNC;

            mainpanel.Visible = false;

            if (GenericLists.ProductsDrinks is null || GenericLists.ProductsDrinks.Count == 0)
            {
                var (product, message) = productsRepository.GetProductByCategory(CategoryConstants.Drinks);
                GenericLists.ProductsDrinks = product;
                if (product is null || !product.Any())
                    MessageBox.Show(message);
            }

            if (GenericLists.ProductsFoods is null || GenericLists.ProductsFoods.Count == 0)
            {
                var (product, message) = productsRepository.GetProductByCategory(CategoryConstants.Foods);
                GenericLists.ProductsFoods = product;
                if (product is null || !product.Any())
                    MessageBox.Show(message);
            }
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
            Application.Exit();
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
