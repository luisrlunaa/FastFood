﻿using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using FastFoodDemo.Utils;
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

        private void SalesForm_Load(object sender, EventArgs e)
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
            var lst = GenericLists.SelectedItems;
            if (lst != null)
            {
                decimal SumaSubTotal = 0; decimal SumaTotal = 0; decimal SumaIgv = 0;
                dgProductSelected.Rows.Clear();
                for (int i = 0; i < lst.Count; i++)
                {
                    dgProductSelected.Rows.Add();
                    dgProductSelected.Rows[i].Cells["IdVenta"].Value = lst[i].IdSale;
                    dgProductSelected.Rows[i].Cells["IdProd"].Value = lst[i].IdProduct;
                    dgProductSelected.Rows[i].Cells["NameProd"].Value = lst[i].ProductName;
                    dgProductSelected.Rows[i].Cells["Quantity"].Value = lst[i].Quantity;
                    dgProductSelected.Rows[i].Cells["PriceProd"].Value = lst[i].Prices;
                    dgProductSelected.Rows[i].Cells["IGV"].Value = lst[i].Itbis;
                    dgProductSelected.Rows[i].Cells["SubTotal"].Value = lst[i].Subtotal;

                    var cantidad = Math.Round(Convert.ToDecimal(dgProductSelected.Rows[i].Cells["Quantity"].Value), 2);
                    var igv = Convert.ToDecimal(dgProductSelected.Rows[i].Cells["IGV"].Value);

                    SumaSubTotal += Math.Round(Convert.ToDecimal(dgProductSelected.Rows[i].Cells["SubTotal"].Value), 2);
                    SumaIgv += igv * cantidad;

                    SumaTotal += (SumaSubTotal + SumaIgv);

                    lblSubTotalAmount.Text = Convert.ToString(SumaSubTotal);
                    lblIgvAmount.Text = Convert.ToString(SumaIgv);
                    lblTotalAmount.Text = Convert.ToString(SumaTotal);

                    var (product, message) = productsRepository.GetProductById(lst[i].IdProduct);
                    var id = new IdsDTO();
                    id.Id = lst[i].IdProduct;
                    id.Quantity = lst[i].Quantity;
                    Lisids.Add(id);
                }
            }
            else
            {
                lblSubTotalAmount.Text = Convert.ToString(0);
                lblIgvAmount.Text = Convert.ToString(0);
                lblTotalAmount.Text = Convert.ToString(0);
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            var sale = new Sales();
            sale.IdEmployee = 0;
            sale.ClientName = txtClientName.Text;
            sale.ClientRnc = txtRncCli.Text;
            sale.Address = txtDireccion.Text;
            sale.SalesCheckType = "Debito";
            sale.DocumentType = combo_tipo_NCF.Text;
            sale.NroComprobante = txtNCF.Text;
            sale.DeliveryName = txtDelivery.Text;
            sale.DeliveryAmount = string.IsNullOrWhiteSpace(txtDAmount.Text) ? 0 : Convert.ToDecimal(txtDAmount.Text);
            sale.Total = Convert.ToDecimal(lblTotalAmount.Text);
            sale.Remaining = 0;
            sale.DateIn = Convert.ToDateTime(dateTimePicker1.Text);
            var (add, message) = salesRepository.AddSale(sale);
            if (add)
            {
                var (addDetails, message1) = salesRepository.AddSaleDetails(GenericLists.SelectedItems);
                if (addDetails)
                {
                    if (Lisids != null && Lisids.Any())
                    {
                        foreach (var item in Lisids)
                        {
                            var (product, message2) = productsRepository.GetProductById(item.Id);
                            if (product != null)
                            {
                                var newProduct = product;
                                newProduct.Stock = product.Stock - item.Quantity;
                                newProduct.Updated = DateTime.Today;
                                var (update, message3) = productsRepository.UpdateProduct(newProduct);
                                if (!update)
                                    MessageBox.Show(message3);
                            }
                            else
                                MessageBox.Show(message2);
                        }
                    }
                }
                else
                    MessageBox.Show(message1);

                GetInfo("Debito");
            }
            else
                MessageBox.Show(message);

            LlenarGri();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            var sale = new Sales();
            sale.IdEmployee = 0;
            sale.ClientName = txtClientName.Text;
            sale.ClientRnc = txtRncCli.Text;
            sale.Address = txtDireccion.Text;
            sale.SalesCheckType = "Debito";
            sale.DocumentType = combo_tipo_NCF.Text;
            sale.NroComprobante = txtNCF.Text;
            sale.DeliveryName = txtDelivery.Text;
            sale.DeliveryAmount = string.IsNullOrWhiteSpace(txtDAmount.Text) ? 0 : Convert.ToDecimal(txtDAmount.Text);
            sale.Total = Convert.ToDecimal(lblTotalAmount.Text);
            sale.Remaining = 0;
            sale.DateIn = Convert.ToDateTime(dateTimePicker1.Text);
            var (add, message) = salesRepository.AddSale(sale);
            if (add)
            {
                var (addDetails, message1) = salesRepository.AddSaleDetails(GenericLists.SelectedItems);
                if (addDetails)
                {
                    if (Lisids != null && Lisids.Any())
                    {
                        foreach (var item in Lisids)
                        {
                            var (product, message2) = productsRepository.GetProductById(item.Id);
                            if (product != null)
                            {
                                var newProduct = product;
                                newProduct.Stock = product.Stock - item.Quantity;
                                newProduct.Updated = DateTime.Today;
                                var (update, message3) = productsRepository.UpdateProduct(newProduct);
                                if (!update)
                                    MessageBox.Show(message3);
                            }
                            else
                                MessageBox.Show(message2);
                        }
                    }
                }
                else
                    MessageBox.Show(message1);

                GetInfo("Credito");
            }
            else
                MessageBox.Show(message);

            LlenarGri();
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
                List<SalesDetails> lista = new List<SalesDetails>();
                var IdProducto = Convert.ToInt32(dgProductSelected.CurrentRow.Cells["IdProd"].Value.ToString());
                if (IdProducto > 0)
                {
                    decimal Igv = 0;
                    decimal subtotal = 0;
                    decimal SumaSubTotal = 0;
                    decimal SumaIgv = 0;
                    decimal SumaTotal = 0;
                    string category = string.Empty;
                    foreach (var item in GenericLists.SelectedItems)
                    {
                        if (item.IdProduct != IdProducto)
                        {
                            lista.Add(item);

                            Igv = item.Itbis;
                            subtotal = item.Prices * item.Quantity;

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

                    GenericLists.SelectedItems = lista;
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
            {
                lblRncCli.Visible = true;
                txtRncCli.Visible = true;
                txtNCF.Enabled = true;
            }
            else
            {
                lblRncCli.Visible = false;
                txtRncCli.Visible = false;
                txtNCF.Enabled = false;
                txtNCF.Text = "Sin NCF";
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
            Program.SaleId = GenericLists.SelectedItems != null && GenericLists.SelectedItems.Any()
                           ? GenericLists.SelectedItems.FirstOrDefault().IdSale.ToString() : 0.ToString();
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
            Print(false);
        }

        public void Print(bool isCopie)
        {
            if (MessageBox.Show("¿Desea Imprimir factura? \n \n", "FoodShop", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                tickStyle(isCopie);
            }
            Lisids = new List<IdsDTO>();
            GenericLists.SelectedItems = new List<SalesDetails>();
        }

        private void tickStyle(bool isCopie)
        {
            CreateTicket ticket = new CreateTicket();
            //cabecera del ticket.
            if (isCopie)
            {
                ticket.TextoDerecha("Copia Factura");
            }

            //System.Drawing.Image img = System.Drawing.Image.FromFile("LogoCepeda.png");
            //ticket.HeaderImage = img;
            ticket.TextoCentro(Program.BusinessName);//Nombre Empresa
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda(Program.BusinessAddress);//Direccion Empresa
            ticket.TextoIzquierda("Tel: " + Program.BusinessPhone1 + "/" + Program.BusinessPhone2);//Telefonos Empresa
            ticket.TextoIzquierda("RNC: " + Program.BusinessRnc);
            if (Program.HasNCF)
            {
                ticket.TextoIzquierda("Tipo de Comprobante: " + Program.TypeNCF);
                ticket.TextoIzquierda("Numero de Comprobante: " + Program.NCF);
            }

            if (!string.IsNullOrWhiteSpace(Program.Delivery))
            {
                ticket.TextoIzquierda("Direccion: " + Program.SaleAddress);
                ticket.TextoIzquierda("Delivery: " + Program.Delivery);
                ticket.TextoIzquierda("Monto por Delivery: " + Program.DeliveryAmount);
            }

            ticket.TextoExtremos("CAJA #1", "ID VENTA: " + Program.SaleId);
            ticket.lineasGuio();
            //SUB CABECERA.
            //ticket.TextoIzquierda("Atendido Por: " + txtUsu.Text);
            ticket.TextoIzquierda("Cliente: " + Program.ClientName);
            ticket.TextoIzquierda("Fecha: " + Program.DateIn);

            //ARTICULOS A VENDER.
            ticket.EncabezadoVenta();// NOMBRE DEL ARTICULO, CANT, PRECIO, IMPORTE
            ticket.lineasGuio();

            //SI TIENE UN DATAGRIDVIEW DONDE ESTAN SUS ARTICULOS A VENDER PUEDEN USAR ESTA MANERA PARA AGREARLOS
            foreach (var detail in GenericLists.SelectedItems)
            {
                ticket.AgregaArticulo(detail.ProductName, detail.Quantity + "x" + detail.Prices, detail.Subtotal, detail.Itbis);
            }

            ticket.TextoIzquierda(" ");

            //resumen de la venta
            ticket.AgregarTotales("SUB-TOTAL    : ", decimal.Parse(Program.SubTotal));
            ticket.AgregarTotales("ITBIS     : ", decimal.Parse(Program.IgvTotal));
            ticket.AgregarTotales("TOTAL A PAGAR    : ", decimal.Parse(Program.Total));

            ticket.TextoIzquierda(" ");
            ticket.TextoCentro("__________________________________");

            //TEXTO FINAL DEL TICKET
            ticket.TextoIzquierda("EXTRA");
            ticket.TextoIzquierda("FAVOR REVISE SU MERCANCIA AL RECIBIRLA");
            ticket.TextoCentro("!GRACIAS POR SU COMPRA!");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda("");
            ticket.CortaTicket();//CORTAR TICKET
            ticket.ImprimirTicket("POS-80 (copy 1)");//NOMBRE DE LA IMPRESORA
        }
    }
}