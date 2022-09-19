using FastFoodDemo.Constants;
using FastFoodDemo.Entities;
using FastFoodDemo.Utils;
using FastFoodDemo.ViewModels.GenericList;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class ManagerProductForm : Form
    {
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
            product.Category = cbxCategoria.Text;

            if (cbxCategoria.Text == CategoryConstants.Drinks)
            {
                var actual = GenericListProducts.ProductsDrinks.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (actual != null)
                    GenericListProducts.ProductsDrinks.Remove(actual);

                GenericListProducts.ProductsDrinks.Add(product);
                DrinkListForm form = new DrinkListForm();
                form.RefreshList();
            }

            if (cbxCategoria.Text == CategoryConstants.Foods)
            {
                var actual = GenericListProducts.ProductsFoods.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (actual != null)
                    GenericListProducts.ProductsFoods.Remove(actual);

                GenericListProducts.ProductsFoods.Add(product);
                FoodListForm form = new FoodListForm();
                form.RefreshList();
            }

            MessageBox.Show("Proceso completado con exito");
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            var product = new Product();
            product.Name = txtProducto.Text;
            product.Description = txtMarca.Text;
            product.BayPrice = Convert.ToDecimal(txtPCompra.Text);
            product.SalesPrice = Convert.ToDecimal(txtPVenta.Text);
            product.Stock = Convert.ToDecimal(txtStock.Text);
            product.Category = cbxCategoria.Text;

            if (cbxCategoria.Text == CategoryConstants.Drinks)
            {
                var actual = GenericListProducts.ProductsDrinks.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (actual != null)
                    GenericListProducts.ProductsDrinks.Remove(actual);

                product.ProductId = GenericListProducts.ProductsDrinks.Max(x => x.ProductId) + 1;
                GenericListProducts.ProductsDrinks.Add(product);
                FoodListForm form = new FoodListForm();
                form.RefreshList();
            }

            if (cbxCategoria.Text == CategoryConstants.Foods)
            {
                var actual = GenericListProducts.ProductsFoods.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (actual != null)
                    GenericListProducts.ProductsFoods.Remove(actual);

                product.ProductId = GenericListProducts.ProductsFoods.Max(x => x.ProductId) + 1;
                GenericListProducts.ProductsFoods.Add(product);
                FoodListForm form = new FoodListForm();
                form.RefreshList();
            }

            MessageBox.Show("Proceso completado con exito");
            Close();
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
