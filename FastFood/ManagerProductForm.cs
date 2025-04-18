﻿using FastFood.FastFood.Infrastructure.Constants;
using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using FastFoodDemo.Utils;
using System;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class ManagerProductForm : Form
    {
        ProductsRepository productsRepository = new ProductsRepository();
        public static ManagerProductForm Instance;
        public ManagerProductForm()
        {
            InitializeComponent();
            Instance = this;
        }

        private void ManagerProductForm_Load(object sender, EventArgs e)
        {
            cbxCategoria.Items.Clear();
            cbxCategoria.Items.Add(CategoryConstants.Drinks);
            cbxCategoria.Items.Add(CategoryConstants.Foods);

            if (!string.IsNullOrWhiteSpace(lblProductId.Text))
            {
                button1.Enabled = true;
                button1.Visible = true;
                btnGuardar.Enabled = false;
                btnGuardar.Visible = false;

                cbxCategoria.SelectedIndex = cbxCategoria.Items.IndexOf(lblcategory.Text);
            }
            else
            {
                button1.Enabled = false;
                button1.Visible = false;
                btnGuardar.Enabled = true;
                btnGuardar.Visible = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var product = new Product();
            product.ProductId = string.IsNullOrWhiteSpace(lblProductId.Text) ? 0 : Convert.ToInt32(lblProductId.Text);
            product.Name = txtProducto.Text;
            product.Description = txtMarca.Text;
            product.Category = cbxCategoria.Text;
            product.Type = txtType.Text;
            product.Stock = string.IsNullOrWhiteSpace(txtStock.Text) ? 0 : Convert.ToDecimal(txtStock.Text);
            product.Itbis = string.IsNullOrWhiteSpace(txtitbis.Text) ? 0 : Convert.ToDecimal(txtitbis.Text);
            product.SalesPrice = string.IsNullOrWhiteSpace(txtPVenta.Text) ? 0 : Convert.ToDecimal(txtPVenta.Text);
            product.BayPrice = string.IsNullOrWhiteSpace(txtPCompra.Text) ? 0 : Convert.ToDecimal(txtPCompra.Text);
            product.Updated = DateTime.Today;
            product.ImageName = txtImgName.Text;

            var (update, message) = productsRepository.UpdateProduct(product);
            if (update)
            {
                if (cbxCategoria.Text == CategoryConstants.Drinks)
                {
                    DrinkListForm form = new DrinkListForm();
                    form.RefreshList();
                }

                if (cbxCategoria.Text == CategoryConstants.Foods)
                {
                    FoodListForm form = new FoodListForm();
                    form.RefreshList();
                }

                MessageBox.Show(message);
                Close();
            }
            else
                MessageBox.Show(message);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var product = new Product();
            product.Name = txtProducto.Text;
            product.Description = txtMarca.Text;
            product.Category = cbxCategoria.Text;
            product.Type = txtType.Text;
            product.Stock = string.IsNullOrWhiteSpace(txtStock.Text) ? 0 : Convert.ToDecimal(txtStock.Text);
            product.Itbis = string.IsNullOrWhiteSpace(txtitbis.Text) ? 0 : Convert.ToDecimal(txtitbis.Text);
            product.SalesPrice = string.IsNullOrWhiteSpace(txtPVenta.Text) ? 0 : Convert.ToDecimal(txtPVenta.Text);
            product.BayPrice = string.IsNullOrWhiteSpace(txtPCompra.Text) ? 0 : Convert.ToDecimal(txtPCompra.Text);
            product.Created = DateTime.Today;
            product.ImageName = txtImgName.Text;

            var (add, message) = productsRepository.AddProduct(product);
            if (add)
            {
                if (cbxCategoria.Text == CategoryConstants.Drinks)
                {
                    DrinkListForm form = new DrinkListForm();
                    form.RefreshList();
                }

                if (cbxCategoria.Text == CategoryConstants.Foods)
                {
                    FoodListForm form = new FoodListForm();
                    form.RefreshList();
                }

                MessageBox.Show(message);
                Close();
            }
            else
                MessageBox.Show(message);
        }

        #region Validations
        private void txtPCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void txtPVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void txtitbis_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.sololetras(e);
        }
        #endregion
    }
}
