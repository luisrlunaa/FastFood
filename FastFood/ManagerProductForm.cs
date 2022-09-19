using FastFoodDemo.Utils;
using Infrastructure.Constants;
using Models.Entities;
using Models.ViewModels.GenericLists;
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
                var actual = GenericLists.ProductsDrinks.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (actual != null)
                    GenericLists.ProductsDrinks.Remove(actual);

                GenericLists.ProductsDrinks.Add(product);
                DrinkListForm form = new DrinkListForm();
                form.RefreshList();
            }

            if (cbxCategoria.Text == CategoryConstants.Foods)
            {
                var actual = GenericLists.ProductsFoods.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (actual != null)
                    GenericLists.ProductsFoods.Remove(actual);

                GenericLists.ProductsFoods.Add(product);
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
                var actual = GenericLists.ProductsDrinks.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (actual != null)
                    GenericLists.ProductsDrinks.Remove(actual);

                product.ProductId = GenericLists.ProductsDrinks.Max(x => x.ProductId) + 1;
                GenericLists.ProductsDrinks.Add(product);
                FoodListForm form = new FoodListForm();
                form.RefreshList();
            }

            if (cbxCategoria.Text == CategoryConstants.Foods)
            {
                var actual = GenericLists.ProductsFoods.FirstOrDefault(x => x.ProductId == product.ProductId);
                if (actual != null)
                    GenericLists.ProductsFoods.Remove(actual);

                product.ProductId = GenericLists.ProductsFoods.Max(x => x.ProductId) + 1;
                GenericLists.ProductsFoods.Add(product);
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
