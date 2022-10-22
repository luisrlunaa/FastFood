using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class SalesListForm : Form
    {
        SalesRepository salesRepository = new SalesRepository();
        public static List<IdsDTO> Lisids { get; set; }
        public static SalesListForm Instance;
        public SalesListForm()
        {
            InitializeComponent();
            Instance = this;
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            Lisids = new List<IdsDTO>();
            var (lst, message) = salesRepository.GetSaleDetailsByDate(dtpFromDate.Value, dtpToDate.Value);
            LlenarGri(lst);
        }

        private void LlenarGri(List<SalesDetails> lst)
        {
            if (lst != null)
            {
                decimal SumaEarningsTotal = 0; decimal SumaTotal = 0;
                dgSalesSelected.Rows.Clear();
                for (int i = 0; i < lst.Count; i++)
                {
                    string datein = string.Empty;
                    if (lst[i].DateIn.HasValue)
                        datein = lst[i].DateIn.Value.ToString("dd/MM/yyyy");

                    dgSalesSelected.Rows.Add();
                    dgSalesSelected.Rows[i].Cells["NameProd"].Value = lst[i].ProductName;
                    dgSalesSelected.Rows[i].Cells["Quantity"].Value = lst[i].Quantity;
                    dgSalesSelected.Rows[i].Cells["PriceProd"].Value = lst[i].Prices;
                    dgSalesSelected.Rows[i].Cells["IGV"].Value = lst[i].Itbis;
                    dgSalesSelected.Rows[i].Cells["SubTotal"].Value = lst[i].Subtotal;
                    dgSalesSelected.Rows[i].Cells["DateIn"].Value = datein;

                    SumaEarningsTotal += Math.Round(lst[i].Earnings, 2);
                    lblEarningsAmount.Text = Convert.ToString(SumaEarningsTotal);

                    SumaTotal += Math.Round(lst[i].Subtotal, 2);
                    lblTotalAmount.Text = Convert.ToString(SumaTotal);
                }
            }
            else
            {
                lblEarningsAmount.Text = Convert.ToString(0);
                lblTotalAmount.Text = Convert.ToString(0);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                return;

            var (lst, message) = salesRepository.GetSaleDetailsByDescriptionOrClientName(txtSearch.Text);
            LlenarGri(lst);
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (dtpFromDate.Value != DateTime.MinValue
                && dtpToDate.Value != DateTime.MinValue
                && (chkDAmount.Checked || chkDSales.Checked))
            {
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    if (chkDAmount.Checked)
                    {
                        var (amount, message) = salesRepository.GetAmountByDeliveryName(txtSearch.Text, dtpFromDate.Value, dtpToDate.Value);
                        lblNMDelibery.Visible = true;
                        lblSMDelibery.Visible = true;
                        lblMDelibery.Visible = true;
                        lblMDelibery.Text = amount.ToString();
                    }

                    if (chkDSales.Checked)
                    {
                        var (lst, message) = salesRepository.GetSaleDetailsByDeliveryName(txtSearch.Text, dtpFromDate.Value, dtpToDate.Value);
                        lblNMDelibery.Visible = false;
                        lblSMDelibery.Visible = false;
                        lblMDelibery.Visible = false;
                        LlenarGri(lst);
                    }
                }
                else
                    MessageBox.Show("Debe introducir el nombre del delivery para realizar la busqueda");

            }
            else
            {
                var (lst, message) = salesRepository.GetSaleDetailsByDate(dtpFromDate.Value, dtpToDate.Value);
                lblNMDelibery.Visible = false;
                lblSMDelibery.Visible = false;
                lblMDelibery.Visible = false;
                LlenarGri(lst);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            To_pdf();
        }

        #region PDF
        private void To_pdf()
        {
            Document doc = new Document(PageSize.LETTER, 10f, 10f, 10f, 0f);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //Image image1 = Image.GetInstance("food.png");
            //image1.ScaleAbsoluteWidth(140);
            //image1.ScaleAbsoluteHeight(70);
            saveFileDialog1.InitialDirectory = @"C:";
            saveFileDialog1.Title = "Guardar Reporte";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string filename = "Reporte" + DateTime.Now.ToString();
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
                    string remito = lblLogo.Text;
                    string ubicado = lblDir.Text;
                    string envio = "Fecha : " + DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;

                    Chunk chunk = new Chunk(remito, FontFactory.GetFont("ARIAL", 16, iTextSharp.text.Font.BOLD, color: BaseColor.BLUE));
                    var fecha = new Paragraph(envio, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.ITALIC));

                    fecha.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(fecha);
                    //image1.Alignment = Image.TEXTWRAP | Image.ALIGN_CENTER;
                    //doc.Add(image1);
                    var chuckalign = new Paragraph(chunk);
                    chuckalign.Alignment = Element.ALIGN_CENTER;
                    doc.Add(chuckalign);
                    var ubicacionalign = new Paragraph(ubicado, FontFactory.GetFont("ARIAL", 9, iTextSharp.text.Font.NORMAL));
                    ubicacionalign.Alignment = Element.ALIGN_CENTER;
                    doc.Add(ubicacionalign);

                    doc.Add(new Paragraph("Reporte de Ventas Realizadas"));
                    doc.Add(new Paragraph("Desde la Fecha: " + (dtpFromDate.Value.Date.Day + "/" + dtpFromDate.Value.Date.Month + "/" + dtpFromDate.Value.Date.Year).ToString() + ", " + "Hasta la Fecha: " + (dtpToDate.Value.Date.Day + "/" + dtpToDate.Value.Date.Month + "/" + dtpToDate.Value.Date.Year).ToString(), FontFactory.GetFont("ARIAL", 7, iTextSharp.text.Font.NORMAL)));
                    doc.Add(new Paragraph("                       "));
                    GenerarDocumento(doc);
                    doc.AddCreationDate();
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Total de Ventas      : " + lblTotalAmount.Text));
                    doc.Add(new Paragraph("Total de Ganancias   : " + lblEarningsAmount.Text));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("____________________________________"));
                    doc.Add(new Paragraph("                         Firma              "));
                    doc.Close();

                    Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
                }
            }
            else
            {
                MessageBox.Show("No guardo el Archivo");
            }
        }

        public void GenerarDocumento(Document document)
        {
            int i, j;
            PdfPTable datatable = new PdfPTable(dgSalesSelected.ColumnCount);
            float[] headerwidths = GetTamañoColumnas(dgSalesSelected);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 1;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_LEFT;
            for (i = 0; i < dgSalesSelected.ColumnCount; i++)
            {
                datatable.AddCell(new Phrase(dgSalesSelected.Columns[i].HeaderText, FontFactory.GetFont("ARIAL", 7, iTextSharp.text.Font.BOLD)));
            }
            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 1;
            for (i = 0; i < dgSalesSelected.Rows.Count; i++)
            {
                for (j = 0; j < dgSalesSelected.Columns.Count; j++)
                {
                    if (dgSalesSelected[j, i].Value != null)
                    {
                        datatable.AddCell(new Phrase(dgSalesSelected[j, i].Value.ToString(), FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.NORMAL)));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
                    }
                }
                datatable.CompleteRow();
            }
            document.Add(datatable);
        }

        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;
        }
        #endregion
    }
}
