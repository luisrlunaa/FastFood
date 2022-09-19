using FastFoodDemo.Constants;
using FastFoodDemo.ViewModels;
using FastFoodDemo.ViewModels.GenericList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class SalesForm : Form
    {
        public static List<IdsDTO> Lisids { get; set; }
        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, System.EventArgs e)
        {
            if (lblSales.Text == "Ventas")
            {
                btnVender.Enabled = true;
                btnVender.Visible = true;
                btnEnviar.Enabled = false;
                btnEnviar.Visible = false;
            }
            else
            {
                btnVender.Enabled = false;
                btnVender.Visible = false;
                btnEnviar.Enabled = true;
                btnEnviar.Visible = true;
            }

            Lisids = new List<IdsDTO>();
            LlenarGri();
        }

        private void LlenarGri()
        {
            var lst = GenericListProducts.SeletedItems;
            if(lst != null)
            {
                decimal SumaSubTotal = 0; decimal SumaTotal = 0; //decimal SumaIgv = 0;
                dgProductSelected.Rows.Clear();
                for (int i = 0; i < lst.Count; i++)
                {
                    dgProductSelected.Rows.Add();
                    dgProductSelected.Rows[i].Cells["IdVenta"].Value = 1;
                    dgProductSelected.Rows[i].Cells["NameProd"].Value = lst[i].Name;
                    dgProductSelected.Rows[i].Cells["Quantity"].Value = lst[i].Quantity;
                    dgProductSelected.Rows[i].Cells["PriceProd"].Value = lst[i].Price;
                    dgProductSelected.Rows[i].Cells["SubTotal"].Value = (lst[i].Quantity * lst[i].Price);

                    var preciounidad = Math.Round(Convert.ToDecimal(dgProductSelected.Rows[i].Cells["PriceProd"].Value), 2);
                    var cantidad = Math.Round(Convert.ToDecimal(dgProductSelected.Rows[i].Cells["Quantity"].Value), 2);
                    //var igv = Convert.ToDecimal(dgProductSelected.Rows[i].Cells["IGV"].Value);

                    SumaSubTotal += preciounidad * cantidad;
                    //SumaIgv += igv * cantidad;

                    SumaTotal += Math.Round(Convert.ToDecimal(dgProductSelected.Rows[i].Cells["SubtoTal"].Value), 2);

                    lblSubTotalAmount.Text = Convert.ToString(SumaSubTotal);
                    //lbligv.Text = Convert.ToString(SumaIgv);
                    lblTotalAmount.Text = Convert.ToString(SumaTotal);

                    var id = new IdsDTO();
                    id.Id = lst[i].Id;
                    id.Quantity = lst[i].Quantity;
                    Lisids.Add(id);
                }
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if(Lisids != null && Lisids.Any())
            {
                foreach (var item in Lisids)
                {
                    var product = GenericListProducts.ProductsFoods.FirstOrDefault(x => x.ProductId == item.Id);
                    if(product != null)
                        product = GenericListProducts.ProductsDrinks.FirstOrDefault(x => x.ProductId == item.Id);

                    if( product != null)
                    {
                        if(product.Category == CategoryConstants.Drinks)
                        {
                            var newProduct = product;
                            newProduct.Stock = product.Stock - item.Quantity;

                            GenericListProducts.ProductsDrinks.Remove(product);
                            GenericListProducts.ProductsDrinks.Add(newProduct);
                        }

                        if (product.Category == CategoryConstants.Foods)
                        {
                            var newProduct = product;
                            newProduct.Stock = product.Stock - item.Quantity;

                            GenericListProducts.ProductsFoods.Remove(product);
                            GenericListProducts.ProductsFoods.Add(newProduct);
                        }
                    }
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Lisids != null && Lisids.Any())
            {
                foreach (var item in Lisids)
                {
                    var product = GenericListProducts.ProductsFoods.FirstOrDefault(x => x.ProductId == item.Id);
                    if (product != null)
                        product = GenericListProducts.ProductsDrinks.FirstOrDefault(x => x.ProductId == item.Id);

                    if (product != null)
                    {
                        if (product.Category == CategoryConstants.Drinks)
                        {
                            var newProduct = product;
                            newProduct.Stock = product.Stock - item.Quantity;

                            GenericListProducts.ProductsDrinks.Remove(product);
                            GenericListProducts.ProductsDrinks.Add(newProduct);
                        }

                        if (product.Category == CategoryConstants.Foods)
                        {
                            var newProduct = product;
                            newProduct.Stock = product.Stock - item.Quantity;

                            GenericListProducts.ProductsFoods.Remove(product);
                            GenericListProducts.ProductsFoods.Add(newProduct);
                        }
                    }
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }

        //dgProductSelected.Rows.Clear();
    }
}
