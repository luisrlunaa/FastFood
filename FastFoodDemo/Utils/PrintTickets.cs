using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FastFoodDemo.Utils
{
    public static class PrintTickets
    {
        public static void Print(bool isCopie, DataGridView dataGridView)
        {
            if (MessageBox.Show("¿Que tipo de factura desea? \n Si=Pequeña \n No=Grande ", "FoodShop", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                tickStyle(isCopie, dataGridView);
            }
            else
            {
                To_pdf(isCopie, dataGridView);
            }
        }

        private static void tickStyle(bool isCopie, DataGridView dataGridView)
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
            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                ticket.AgregaArticulo(fila.Cells["NameProd"].Value.ToString().Trim(),
                                      fila.Cells["Quantity"].Value.ToString().Trim() + "x" + fila.Cells["PriceProd"].Value.ToString().Trim(),
                                      decimal.Parse(fila.Cells["SubTotal"].Value.ToString().Trim()),
                                      decimal.Parse(fila.Cells["IGV"].Value.ToString().Trim()));
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

        private static void To_pdf(bool isCopie, DataGridView dataGridView)
        {
            Document doc = new Document(PageSize.LETTER, 10f, 10f, 10f, 0f);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            Image image1 = Image.GetInstance("LogoCepeda.png");
            image1.ScaleAbsoluteWidth(140);
            image1.ScaleAbsoluteHeight(70);
            saveFileDialog1.InitialDirectory = @"C:";
            saveFileDialog1.Title = "Factura para " + "";//NOmbre Cliente
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string filename = "Venta" + DateTime.Now.ToString();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;

                if (filename.Trim() != "")
                {
                    FileStream file = new FileStream(filename,
                    FileMode.OpenOrCreate,
                    FileAccess.ReadWrite,
                    FileShare.ReadWrite);
                    PdfWriter.GetInstance(doc, file);
                    doc.Open();
                    string remito = Program.BusinessName;
                    string ubicado = Program.BusinessAddress;
                    string envio = "Fecha : " + Program.DateIn;

                    Chunk chunk = new Chunk(remito, FontFactory.GetFont("ARIAL", 16, Font.BOLD, color: BaseColor.BLUE));
                    if (isCopie)
                    {
                        doc.Add(new Paragraph("                                                                                                                                                                                                                                                                                                                                                                                            " + "Copia Factura", FontFactory.GetFont("ARIAL", 5, Font.ITALIC, color: BaseColor.RED)));
                    }

                    var fecha = new Paragraph(envio, FontFactory.GetFont("ARIAL", 8, Font.ITALIC));

                    fecha.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(fecha);
                    image1.Alignment = Image.TEXTWRAP | Element.ALIGN_CENTER;
                    doc.Add(image1);
                    var chuckalign = new Paragraph(chunk);
                    chuckalign.Alignment = Element.ALIGN_CENTER;
                    doc.Add(chuckalign);
                    var ubicacionalign = new Paragraph(ubicado, FontFactory.GetFont("ARIAL", 9, Font.NORMAL));
                    ubicacionalign.Alignment = Element.ALIGN_CENTER;
                    doc.Add(ubicacionalign);
                    var telefonos = new Paragraph("Tel: " + Program.BusinessPhone1 + " / " + Program.BusinessPhone2, FontFactory.GetFont("ARIAL", 8, Font.NORMAL));
                    telefonos.Alignment = Element.ALIGN_CENTER;
                    doc.Add(telefonos);
                    var RNC = new Paragraph("RNC: " + Program.BusinessRnc, FontFactory.GetFont("ARIAL", 8, Font.NORMAL));
                    RNC.Alignment = Element.ALIGN_CENTER;
                    doc.Add(RNC);

                    if (Program.HasNCF)
                    {
                        doc.Add(new Paragraph("Tipo de Comprobante: " + Program.TypeNCF, FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));
                        doc.Add(new Paragraph("Numero de Comprobante: " + Program.NCF, FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));
                    }

                    doc.Add(new Paragraph(" "));
                    if (!string.IsNullOrWhiteSpace(Program.Delivery))
                    {
                        doc.Add(new Paragraph("Direccion: " + Program.SaleAddress.ToUpper(), FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));
                        doc.Add(new Paragraph("Delivery: " + Program.Delivery.ToUpper(), FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));
                        doc.Add(new Paragraph("Monto por Delivery: " + Program.DeliveryAmount.ToUpper(), FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));
                    }

                    doc.Add(new Paragraph("Cliente: " + Program.ClientName, FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));
                    //doc.Add(new Paragraph("Documento de Identificación: " + cedula, FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));
                    doc.Add(new Paragraph(" "));

                    GenerarDocumento(doc, dataGridView);
                    doc.AddCreationDate();
                    if (dataGridView.Rows.Count >= 1)
                    {
                        int filas = 20 - dataGridView.Rows.Count;
                        if (filas > 1)
                        {
                            for (int i = 1; i < filas; i++)
                            {
                                doc.Add(new Paragraph("                       "));
                            }
                        }
                    }

                    decimal Sub = Convert.ToDecimal(Program.SubTotal);
                    decimal ITBIS = Convert.ToDecimal(Program.IgvTotal);
                    decimal total = Convert.ToDecimal(Program.Total);

                    doc.Add(new Paragraph("Sub-Total   : " + Sub.ToString("C2"), FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));
                    doc.Add(new Paragraph("ITBIS   : " + ITBIS.ToString("C2"), FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));
                    doc.Add(new Paragraph("Total a Pagar   : " + total.ToString("C2"), FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));

                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("_________________________" + "                                                                                                                                                 " + "_________________________", FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));
                    doc.Add(new Paragraph("      Facturado Por      " + "                                                                                                                                                                         " + "     Recibido Por  ", FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));
                    doc.Add(new Paragraph("                       "));

                    //var Nota = new Paragraph("Nota: Los productos con garantia pierden su garantia si deja perder la factura.", FontFactory.GetFont("ARIAL", 6, Font.ITALIC, color: BaseColor.RED));
                    //Nota.Alignment = Element.ALIGN_RIGHT;
                    var favor = new Paragraph("FAVOR REVISE SU MERCANCIA AL RECIBIRLA", FontFactory.GetFont("ARIAL", 6, Font.ITALIC, color: BaseColor.RED));
                    favor.Alignment = Element.ALIGN_RIGHT;
                    var gracias = new Paragraph("!GRACIAS POR SU COMPRA!", FontFactory.GetFont("ARIAL", 6, Font.ITALIC, color: BaseColor.RED));
                    gracias.Alignment = Element.ALIGN_RIGHT;

                    //doc.Add(Nota);
                    doc.Add(favor);
                    doc.Add(gracias);

                    doc.Close();
                    Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
                }
            }
            else
            {
                MessageBox.Show("No guardo el Archivo");
            }
        }

        private static void GenerarDocumento(Document document, DataGridView dataGridView)
        {
            int i, j;
            PdfPTable datatable = new PdfPTable(dataGridView.ColumnCount);
            float[] headerwidths = GetTamañoColumnas(dataGridView);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            for (i = 0; i < dataGridView.ColumnCount; i++)
            {
                datatable.AddCell(new Phrase(dataGridView.Columns[i].HeaderText, FontFactory.GetFont("ARIAL", 7, Font.BOLD)));
            }
            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 1;
            for (i = 0; i < dataGridView.Rows.Count; i++)
            {
                for (j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView[j, i].Value != null)
                    {
                        datatable.AddCell(new Phrase(dataGridView[j, i].Value.ToString(), FontFactory.GetFont("ARIAL", 8, Font.NORMAL)));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
                    }
                }
                datatable.CompleteRow();
            }
            document.Add(datatable);
        }

        private static float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = dg.Columns[i].Width;
            }
            return values;
        }
    }
}
