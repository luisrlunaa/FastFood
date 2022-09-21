using FastFoodDemo.Utils;
using Infrastructure.DataAccess.Repositories;
using Models.Entities;
using Models.ViewModels;
using Models.ViewModels.GenericLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class SalesForm : Form
    {
        ProductsRepository productsRepository = new ProductsRepository();
        SalesRepository salesRepository = new SalesRepository();
        public static List<IdsDTO> Lisids { get; set; }
        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, System.EventArgs e)
        {
            var (idVenta, message) = salesRepository.GetNextSalesId();
            if (idVenta == 0)
                MessageBox.Show(message);

            lblIdSale.Text = idVenta.ToString();
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
            var lst = GenericLists.SeletedItems;
            if (lst != null)
            {
                decimal SumaSubTotal = 0; decimal SumaTotal = 0; decimal SumaIgv = 0;
                dgProductSelected.Rows.Clear();
                for (int i = 0; i < lst.Count; i++)
                {
                    dgProductSelected.Rows.Add();
                    dgProductSelected.Rows[i].Cells["IdVenta"].Value = lblIdSale.Text;
                    dgProductSelected.Rows[i].Cells["IdProd"].Value = lst[i].Id;
                    dgProductSelected.Rows[i].Cells["NameProd"].Value = lst[i].Name;
                    dgProductSelected.Rows[i].Cells["Quantity"].Value = lst[i].Quantity;
                    dgProductSelected.Rows[i].Cells["PriceProd"].Value = lst[i].Price;
                    dgProductSelected.Rows[i].Cells["IGV"].Value = lst[i].Igv;
                    dgProductSelected.Rows[i].Cells["SubTotal"].Value = (lst[i].Quantity * lst[i].Price);

                    var preciounidad = Math.Round(Convert.ToDecimal(dgProductSelected.Rows[i].Cells["PriceProd"].Value), 2);
                    var cantidad = Math.Round(Convert.ToDecimal(dgProductSelected.Rows[i].Cells["Quantity"].Value), 2);
                    var igv = Convert.ToDecimal(dgProductSelected.Rows[i].Cells["IGV"].Value);

                    SumaSubTotal += preciounidad * cantidad;
                    SumaIgv += igv * cantidad;

                    SumaTotal += Math.Round(Convert.ToDecimal(dgProductSelected.Rows[i].Cells["SubtoTal"].Value), 2);

                    lblSubTotalAmount.Text = Convert.ToString(SumaSubTotal);
                    lblIgvAmount.Text = Convert.ToString(SumaIgv);
                    lblTotalAmount.Text = Convert.ToString(SumaTotal);

                    var id = new IdsDTO();
                    id.Id = lst[i].Id;
                    id.Quantity = lst[i].Quantity;
                    Lisids.Add(id);
                }
            }
        }

        private void GetInfo(string type)
        {
            //Business Info
            Program.BusinessAddress = lblDir.Text;
            Program.BusinessName = lblLogo.Text;
            Program.BusinessPhone1 = lblTel1.Text;
            Program.BusinessPhone2 = lblTel2.Text;
            Program.BusinessRnc = lblRNC.Text;

            //Sales Info
            Program.SaleId = lblIdSale.Text;
            Program.ClientName = txtClientName.Text;
            Program.SaleAddress = txtDireccion.Text;
            Program.DateIn = dateTimePicker1.Text;
            Program.TypeNCF = combo_tipo_NCF.Text;
            Program.NCF = txtNCF.Text;
            Program.SalesCheckType = type;
            Program.Delivery = txtDelivery.Text;
            Program.DeliveryAmount = txtDAmount.Text;
            Program.HasNCF = chkComprobante.Checked;
            Program.SubTotal = lblSubTotalAmount.Text;
            Program.IgvTotal = lblIgvAmount.Text;
            Program.Total = lblTotalAmount.Text;
            PrintTickets.Print(false, dgProductSelected);
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            var sale = new SalesCheck();
            sale.IdVenta = Convert.ToInt32(Program.SaleId);
            sale.ClientName = Program.ClientName;
            sale.Address = Program.SaleAddress;
            sale.DateIn = Convert.ToDateTime(Program.DateIn);
            sale.DocumentType = Program.TypeNCF;
            sale.NroComprobante = Program.NCF;
            sale.SalesCheckType = Program.SalesCheckType;
            sale.DeliveryName = Program.Delivery;
            sale.DeliveryAmount = string.IsNullOrWhiteSpace(Program.DeliveryAmount) ? 0 : Convert.ToDecimal(Program.DeliveryAmount);
            sale.Subtotal = Convert.ToDecimal(Program.SubTotal);
            sale.Total = Convert.ToDecimal(Program.Total);
            var (add, message) = salesRepository.AddSale(sale);
            if (add)
            {
                if (Lisids != null && Lisids.Any())
                {
                    foreach (var item in Lisids)
                    {
                        var (product, message1) = productsRepository.GetProductById(item.Id);
                        if (product != null)
                        {
                            var newProduct = product;
                            newProduct.Stock = product.Stock - item.Quantity;
                            var (update, message2) = productsRepository.UpdateProduct(newProduct);
                            if (!update)
                                MessageBox.Show(message2);
                        }
                        else
                            MessageBox.Show(message1);
                    }
                }
                GetInfo("Debito");
            }
            else
                MessageBox.Show(message);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            var sale = new SalesCheck();
            sale.IdVenta = Convert.ToInt32(Program.SaleId);
            sale.ClientName = Program.ClientName;
            sale.Address = Program.SaleAddress;
            sale.DateIn = Convert.ToDateTime(Program.DateIn);
            sale.DocumentType = Program.TypeNCF;
            sale.NroComprobante = Program.NCF;
            sale.SalesCheckType = Program.SalesCheckType;
            sale.DeliveryName = Program.Delivery;
            sale.DeliveryAmount = string.IsNullOrWhiteSpace(Program.DeliveryAmount) ? 0 : Convert.ToDecimal(Program.DeliveryAmount);
            sale.Subtotal = Convert.ToDecimal(Program.SubTotal);
            sale.Total = Convert.ToDecimal(Program.Total);
            var (add, message) = salesRepository.AddSale(sale);
            if (add)
            {
                if (Lisids != null && Lisids.Any())
                {
                    foreach (var item in Lisids)
                    {
                        var (product, message1) = productsRepository.GetProductById(item.Id);
                        if (product != null)
                        {
                            var newProduct = product;
                            newProduct.Stock = product.Stock - item.Quantity;
                            var (update, message2) = productsRepository.UpdateProduct(newProduct);
                            if (!update)
                                MessageBox.Show(message2);
                        }
                        else
                            MessageBox.Show(message1);
                    }
                }
                GetInfo("Credito");
            }
            else
                MessageBox.Show(message);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgProductSelected_Click(object sender, EventArgs e)
        {
            btnBorrar.Visible = true;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro desea quitar este Item de la factura?", "FoodShop", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                List<SeletedItem> lista = new List<SeletedItem>();
                var IdProducto = Convert.ToInt32(dgProductSelected.CurrentRow.Cells["IdProd"].Value.ToString());
                if (IdProducto > 0)
                {
                    decimal Igv = 0;
                    decimal subtotal = 0;
                    decimal SumaSubTotal = 0;
                    decimal SumaIgv = 0;
                    decimal SumaTotal = 0;
                    string category = string.Empty;
                    foreach (var item in GenericLists.SeletedItems)
                    {
                        if (item.Id != IdProducto)
                        {
                            lista.Add(item);

                            Igv = item.Igv;
                            subtotal = item.Price * item.Quantity;

                            SumaSubTotal += subtotal;
                            SumaIgv += Igv;
                            SumaTotal = SumaSubTotal + SumaIgv;
                        }
                        else
                        {
                            category = item.Category;
                            lista.Remove(item);
                        }
                    }

                    GenericLists.SeletedItems = lista;
                    btnBorrar.Visible = false;
                    dgProductSelected.Rows.RemoveAt(dgProductSelected.SelectedRows[0].Index);
                    LlenarGri();
                }
                else
                {
                    MessageBox.Show("Por Favor Seleccione un Item antes de eliminarlo");
                }
            }
        }

        private void chkComprobante_CheckedChanged(object sender, EventArgs e)
        {
            if (chkComprobante.Checked)
                txtNCF.Enabled = true;
            else
            {
                txtNCF.Enabled = false;
                txtNCF.Text = "Sin NCF";
            }
        }
    }
}
