﻿using FastFood.Infrastructure.DataAccess.Repositories;
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

            mainpanel.Visible = true;
            SidePanel.Height = button4.Height;
            SidePanel.Top = button4.Top;

            loadform(SalesForm.Instance);
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
            SalesForm.Instance = new SalesForm();
            SalesForm.Instance.lblSales.Text = "Ventas";
            SalesForm.Instance.lblDir.Text = lblDir.Text;
            SalesForm.Instance.lblLogo.Text = lblLogo.Text;
            SalesForm.Instance.lblTel1.Text = lblTel1.Text;
            SalesForm.Instance.lblTel2.Text = lblTel2.Text;
            SalesForm.Instance.lblRNC.Text = lblRNC.Text;
            SalesForm.Instance.lblSales.ForeColor = Color.Black;
            SalesForm.Instance.panelIdentify.BackColor = Color.ForestGreen;

            mainpanel.Visible = true;
            SidePanel.Height = button6.Height;
            SidePanel.Top = button6.Top;

            loadform(SalesForm.Instance);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            BoxSquareForm.Instance = new BoxSquareForm();
            BoxSquareForm.Instance.lblDir.Text = lblDir.Text;
            BoxSquareForm.Instance.lblLogo.Text = lblLogo.Text;

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

            mainpanel.Visible = true;
            SidePanel.Height = btnListSales.Height;
            SidePanel.Top = btnListSales.Top;

            loadform(SalesListForm.Instance);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = true;
            loadform(new ConfigurationsForm());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            mainpanel.Visible = true;
            SidePanel.Height = button7.Height;
            SidePanel.Top = button7.Top;

            loadform(new ClientsForm());
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
