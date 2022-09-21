using FastFoodDemo.Utils;
using Infrastructure.Constants;
using Infrastructure.DataAccess.Repositories;
using Models.Entities;
using System;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class ManagerProductForm : Form
    {
        ProductsRepository productsRepository = new ProductsRepository();
        public ManagerProductForm()
        {
            InitializeComponent();
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
            product.ProductId = Convert.ToInt32(lblProductId.Text);
            product.Name = txtProducto.Text;
            product.Description = txtMarca.Text;
            product.BayPrice = Convert.ToDecimal(txtPCompra.Text);
            product.SalesPrice = Convert.ToDecimal(txtPVenta.Text);
            product.Stock = Convert.ToDecimal(txtStock.Text);
            product.Itbis = Convert.ToDecimal(txtitbis.Text);
            product.Category = cbxCategoria.Text;

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
            product.ProductId = Convert.ToInt32(lblProductId.Text);
            product.Name = txtProducto.Text;
            product.Description = txtMarca.Text;
            product.BayPrice = Convert.ToDecimal(txtPCompra.Text);
            product.SalesPrice = Convert.ToDecimal(txtPVenta.Text);
            product.Stock = Convert.ToDecimal(txtStock.Text);
            product.Itbis = Convert.ToDecimal(txtitbis.Text);
            product.Category = cbxCategoria.Text;

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
