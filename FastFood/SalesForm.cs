using FastFood.Infrastructure.Constants;
using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using FastFoodDemo.Utils;
using Models.ViewModels;
using Models.ViewModels.GenericLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FastFood.Infrastructure.Utils;

namespace FastFoodDemo
{
    public partial class SalesForm : Form
    {
        ProductsRepository productsRepository = new ProductsRepository();
        SalesRepository salesRepository = new SalesRepository();
        NcfRepository ncfsRepository = new NcfRepository();
        public string PrintName = string.Empty;
        public string BusinessAccess;
        public bool hasNCFAccess = false;
        public static SalesForm Instance;
        public static List<IdsDTO> Lisids { get; set; }
        public SalesForm()
        {
            InitializeComponent();
            Instance = this;
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            hasNCFAccess = Access(BusinessPermissName.NCF);
            chkComprobante.Visible = hasNCFAccess;
            label13.Visible = hasNCFAccess;
            combo_tipo_NCF.Visible = hasNCFAccess;
            label2.Visible = hasNCFAccess;
            txtNCF.Visible = hasNCFAccess;
            checkBox1.Visible = Access(BusinessPermissName.Client);

            if (hasNCFAccess)
            {
                var (ncfs, message) = ncfsRepository.GetActivesNCFs();
                if (message.Contains("Error"))
                    MessageBox.Show(message);

                combo_tipo_NCF.Items.Clear();
                combo_tipo_NCF.DisplayMember = "Description_ncf";
                combo_tipo_NCF.ValueMember = "Id_ncf";
                combo_tipo_NCF.DataSource = ncfs;

                txtNCF.Text = "Sin NCF";
            }

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
            if (string.IsNullOrWhiteSpace(txtClientName.Text))
            {
                MessageBox.Show("Nombre del Cliente es obligatorio");
                return;
            }

            if (GenericLists.SelectedItems is null || !GenericLists.SelectedItems.Any())
            {
                MessageBox.Show("Debe tener agregado al menos un producto para realizar una venta");
                return;
            }

            var sale = new Sales();
            sale.IdEmployee = 0;
            sale.ClientName = txtClientName.Text;
            sale.ClientRnc = txtRncCli.Text;
            sale.ClientPhone = txtPhone.Text;
            sale.Address = txtDireccion.Text;
            sale.SalesCheckType = "Debito";
            sale.DocumentType = hasNCFAccess && chkComprobante.Checked ? combo_tipo_NCF.Text : string.Empty;
            sale.NroComprobante = hasNCFAccess && chkComprobante.Checked ? txtNCF.Text : "Sin NCF";
            sale.DeliveryName = txtDelivery.Text;
            sale.DeliveryAmount = string.IsNullOrWhiteSpace(txtDAmount.Text) ? 0 : Convert.ToDecimal(txtDAmount.Text);
            sale.Total = Convert.ToDecimal(lblTotalAmount.Text);
            sale.Remaining = 0;
            sale.DateIn = Convert.ToDateTime(dateTimePicker1.Text);
            var (add, message) = salesRepository.AddSale(sale);
            if (add)
            {
                if (hasNCFAccess)
                {
                    var newncf = new NCFGenerated()
                    {
                        Id_sequence = Convert.ToInt32(combo_tipo_NCF.SelectedValue),
                        SequenceNCF = txtNCF.Text,
                        Datein = DateTime.Today
                    };

                    ncfsRepository.AddNCFGenerated(newncf);
                }

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

                Print(false);
            }
            else
                MessageBox.Show(message);

            LlenarGri();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClientName.Text))
            {
                MessageBox.Show("Nombre del Cliente es obligatorio");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                MessageBox.Show("Direccion es obligatoria para hacer un envio");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDelivery.Text))
            {
                MessageBox.Show("Nombre del Delivery es obligatorio para hacer un envio");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDAmount.Text))
            {
                MessageBox.Show("Monto del Delivery es obligatorio para hacer un envio");
                return;
            }

            if (GenericLists.SelectedItems is null || !GenericLists.SelectedItems.Any())
            {
                MessageBox.Show("Debe tener agregado al menos un producto para realizar una venta");
                return;
            }

            var sale = new Sales();
            sale.IdEmployee = 0;
            sale.ClientName = txtClientName.Text;
            sale.ClientRnc = txtRncCli.Text;
            sale.Address = txtDireccion.Text;
            sale.SalesCheckType = "Debito";
            sale.DocumentType = chkComprobante.Checked ? combo_tipo_NCF.Text : string.Empty;
            sale.NroComprobante = chkComprobante.Checked ? txtNCF.Text : "Sin NCF";
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

                Print(false);
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
            if (hasNCFAccess && chkComprobante.Checked)
            {
                lblRncCli.Visible = true;
                txtRncCli.Visible = true;
            }
            else
            {
                lblRncCli.Visible = false;
                txtRncCli.Visible = false;
                txtNCF.Enabled = false;
                txtNCF.Text = "Sin NCF";
            }
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
            var id = GenericLists.SelectedItems != null && GenericLists.SelectedItems.Any()
                           ? GenericLists.SelectedItems.FirstOrDefault().IdSale.ToString() : 0.ToString();

            CreateTicket ticket = new CreateTicket();
            //cabecera del ticket.
            if (isCopie)
            {
                ticket.TextoDerecha("Copia Factura");
            }

            //System.Drawing.Image img = System.Drawing.Image.FromFile("LogoCepeda.png");
            //ticket.HeaderImage = img;
            ticket.TextoCentro(lblLogo.Text);//Nombre Empresa
            ticket.TextoIzquierda("");
            ticket.TextoIzquierda(lblDir.Text);//Direccion Empresa
            ticket.TextoIzquierda("Tel: " + lblTel1.Text + (!string.IsNullOrWhiteSpace(lblTel2.Text) ? "/" + lblTel2.Text : string.Empty));//Telefonos Empresa
            ticket.TextoIzquierda("RNC: " + lblRNC.Text);
            if (hasNCFAccess && chkComprobante.Checked)
            {
                ticket.TextoIzquierda("Tipo de Comprobante: " + combo_tipo_NCF.Text);
                ticket.TextoIzquierda("Numero de Comprobante: " + txtNCF.Text);
            }

            if (!string.IsNullOrWhiteSpace(txtDelivery.Text))
            {
                ticket.TextoIzquierda("Direccion: " + txtDireccion.Text);
                ticket.TextoIzquierda("Delivery: " + txtDelivery.Text);
                ticket.TextoIzquierda("Monto por Delivery: " + txtDAmount.Text);
            }

            ticket.TextoExtremos("CAJA #1", "ID VENTA: " + id);
            ticket.lineasGuio();
            //SUB CABECERA.
            //ticket.TextoIzquierda("Atendido Por: " + txtUsu.Text);
            ticket.TextoIzquierda("Cliente: " + txtClientName.Text);
            ticket.TextoIzquierda("RNC / Cedula Cliente: " + txtRncCli.Text);
            ticket.TextoIzquierda("Fecha: " + dateTimePicker1.Value.ToShortDateString().Replace("/", "-"));

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
            ticket.AgregarTotales("SUB-TOTAL    : ", decimal.Parse(lblSubTotalAmount.Text));
            ticket.AgregarTotales("ITBIS     : ", decimal.Parse(lblIgvAmount.Text));
            ticket.AgregarTotales("TOTAL A PAGAR    : ", decimal.Parse(lblTotalAmount.Text));

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
            ticket.ImprimirTicket(PrintName);//NOMBRE DE LA IMPRESORA
        }

        private void combo_tipo_NCF_SelectedIndexChanged(object sender, EventArgs e)
        {
            var (next, message) = ncfsRepository.GetNextNCFbyId(Convert.ToInt32(combo_tipo_NCF.SelectedValue));
            if (message.Contains("Error"))
                MessageBox.Show(message);

            txtNCF.Text = next;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                txtClientName.Text = string.Empty;
                txtRncCli.Text = string.Empty;
            }
            else
            {
                Program.CallTo = nameof(SalesForm);
                var clientlist = new ClientsForm();
                clientlist.Show();
            }
        }

        public bool Access(string accessName)
        {
            var businessAccess = string.IsNullOrWhiteSpace(BusinessAccess)
                                              ? new List<string>()
                                              : BusinessAccess.Split(',').ToList().CleanSpaceList();

            if (businessAccess != null && businessAccess.Any())
                return businessAccess.Contains(accessName);

            return false;
        }
    }
}
