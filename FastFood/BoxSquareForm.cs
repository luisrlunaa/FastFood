using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using FastFoodDemo.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class BoxSquareForm : Form
    {
        BoxSquareRepository boxSquareRepository = new BoxSquareRepository();
        SalesRepository salesRepository = new SalesRepository();
        public BoxSquareForm()
        {
            InitializeComponent();
        }

        private void agregargasto_Click(object sender, EventArgs e)
        {
            GetAmountInBox(dpkfechacuadre.Value);

            var (box, message) = boxSquareRepository.GetBoxSquareByDate(dpkfechacuadre.Value);
            if (message.Contains("Error"))
                MessageBox.Show(message);

            txtde5.Text = "0";
            txtde10.Text = "0";
            txtde25.Text = "0";
            txtde50.Text = "0";
            txtde100.Text = "0";
            txtde200.Text = "0";
            txtde500.Text = "0";
            txtde1000.Text = "0";
            txtde2000.Text = "0";

            if (!string.IsNullOrWhiteSpace(box.Description))
            {
                string[] valores = box.Description.Split(',');

                txtde5.Text = valores[0];
                txtde10.Text = valores[1];
                txtde25.Text = valores[2];
                txtde50.Text = valores[3];
                txtde100.Text = valores[4];
                txtde200.Text = valores[5];
                txtde500.Text = valores[6];
                txtde1000.Text = valores[7];
                txtde2000.Text = valores[8];
            }

            txtde5.ReadOnly = true;
            txtde10.ReadOnly = true;
            txtde25.ReadOnly = true;
            txtde50.ReadOnly = true;
            txtde100.ReadOnly = true;
            txtde200.ReadOnly = true;
            txtde500.ReadOnly = true;
            txtde1000.ReadOnly = true;
            txtde2000.ReadOnly = true;

            lblmontocuadre.Text = box.Amount.ToString();

            decimal monto = 0;
            if (lblmontoingreso.Text != "...")
            {
                monto = Math.Round(Convert.ToDecimal(lblmontoingreso.Text), 2);
            }

            if (monto < box.Amount)
            {
                var sobrantes = box.Amount - monto;
                lblmensaje.Text = "Cuadre excitoso Sobran : \n" + sobrantes + " Pesos";
                lblmensaje.ForeColor = System.Drawing.Color.Green;
                btnregistrar.Enabled = true;
            }
            else if (monto == box.Amount)
            {
                lblmensaje.Text = "Cuadre exacto";
                lblmensaje.ForeColor = System.Drawing.Color.MidnightBlue;
                btnregistrar.Enabled = true;
            }
            else
            {
                var faltantes = monto - box.Amount;
                lblmensaje.Text = "Cuadre defectuoso, Faltan : \n" + faltantes + " Pesos";
                lblmensaje.ForeColor = System.Drawing.Color.DarkRed;
                btnregistrar.Enabled = false;
            }

            btnregistrar.Visible = false;
            btnimprimir.Visible = true;
            btnsuma.Visible = false;
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            if (lblmontocuadre.Text != "..." && !string.IsNullOrWhiteSpace(lblmontocuadre.Text))
            {
                decimal montofinal = string.IsNullOrWhiteSpace(lblmontocuadre.Text) ? 0 : Convert.ToDecimal(lblmontocuadre.Text);
                if (montofinal > 0)
                {
                    var box = new BoxSquare();
                    box.Description = txtde5.Text + "," + txtde10.Text + "," + txtde25.Text + "," + txtde50.Text + ","
                                    + txtde100.Text + "," + txtde200.Text + "," + txtde500.Text + "," + txtde1000.Text + ","
                                    + txtde2000.Text;
                    box.Amount = montofinal;
                    box.DateIn = DateTime.Today;
                    var (add, message) = boxSquareRepository.AddBoxSquare(box);
                    MessageBox.Show(message);
                    To_pdf();
                    limpiar();
                    label8.Enabled = true;
                }
                else
                    MessageBox.Show("El monto debe ser mayor a cero para registrar un nuevo Cuadre");
            }
            else
                MessageBox.Show("Debe darle al boton de Sumar antes de registrar un nuevo Cuadre");
        }

        private void btnsuma_Click(object sender, EventArgs e)
        {
            if(lblmontocaja.Text == "...")
                GetAmountInBox(dpkfechacuadre.Value);

            if(lblmontocaja.Text == 0.ToString())
            {
                MessageBox.Show("El monto en caja debe ser mayor a cero para registrar un nuevo Cuadre");
                return;
            }

            //decimal inicial = 0;
            //decimal ingresos = 0;
            //decimal gastos = 0;

            //if (lblmontogasto.Text != "...")
            //{
            //    gastos = Math.Round(Convert.ToDecimal(lblmontogasto.Text));
            //}

            //if (lblmontoingreso.Text != "...")
            //{
            //    ingresos = Math.Round(Convert.ToDecimal(lblmontoingreso.Text));
            //}

            //if (lblmontoinicial.Text != "...")
            //{
            //    inicial = Math.Round(Convert.ToDecimal(lblmontoinicial.Text));
            //}

            decimal cuadre = /*(ingresos + inicial) - gastos*/ Math.Round(Convert.ToDecimal(lblmontocaja.Text),2);

            if (string.IsNullOrWhiteSpace(lbldeudas.Text))
            {
                lbldeudas.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtde5.Text))
            {
                txtde5.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtde10.Text))
            {
                txtde10.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtde25.Text))
            {
                txtde25.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtde50.Text))
            {
                txtde50.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtde100.Text))
            {
                txtde100.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtde200.Text))
            {
                txtde200.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtde500.Text))
            {
                txtde500.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtde1000.Text))
            {
                txtde1000.Text = "0";
            }

            if (string.IsNullOrWhiteSpace(txtde2000.Text))
            {
                txtde2000.Text = "0";
            }

            decimal total = Math.Round((5 * decimal.Parse(txtde5.Text)) + (10 * decimal.Parse(txtde10.Text)) + (25 * decimal.Parse(txtde25.Text)) +
                                       (50 * decimal.Parse(txtde50.Text)) + (100 * decimal.Parse(txtde100.Text)) + (200 * decimal.Parse(txtde200.Text)) +
                                       (500 * decimal.Parse(txtde500.Text)) + (1000 * decimal.Parse(txtde1000.Text)) + (2000 * decimal.Parse(txtde2000.Text)));

            if (cuadre < total)
            {
                var sobrantes = total - cuadre;
                lblmensaje.Text = "Cuadre excitoso Sobran : \n" + sobrantes + " Pesos";
                lblmensaje.ForeColor = System.Drawing.Color.Green;
                btnregistrar.Enabled = true;
            }
            else if (cuadre == total)
            {
                lblmensaje.Text = "Cuadre exacto";
                lblmensaje.ForeColor = System.Drawing.Color.MidnightBlue;
                btnregistrar.Enabled = true;
            }
            else
            {
                var faltantes = cuadre - total;
                lblmensaje.Text = "Cuadre defectuoso, Faltan : \n" + faltantes + " Pesos";
                lblmensaje.ForeColor = System.Drawing.Color.DarkRed;
                btnregistrar.Enabled = false;
            }

            lblmontocuadre.Text = total.ToString();
        }

        public void limpiar()
        {
            txtde5.Text = "0";
            txtde10.Text = "0";
            txtde25.Text = "0";
            txtde50.Text = "0";
            txtde100.Text = "0";
            txtde200.Text = "0";
            txtde500.Text = "0";
            txtde1000.Text = "0";
            txtde2000.Text = "0";

            txtde5.ReadOnly = false;
            txtde10.ReadOnly = false;
            txtde25.ReadOnly = false;
            txtde50.ReadOnly = false;
            txtde100.ReadOnly = false;
            txtde200.ReadOnly = false;
            txtde500.ReadOnly = false;
            txtde1000.ReadOnly = false;
            txtde2000.ReadOnly = false;

            //lbldeudas.Text = "...";
            lblmontocuadre.Text = "...";
            lblmontocaja.Text = "...";
            //lblmontoingreso.Text = "...";
            //lblmontogasto.Text = "...";
        }

        private void To_pdf()
        {
            Document doc = new Document(PageSize.LETTER, 10f, 10f, 10f, 0f);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:";
            saveFileDialog1.Title = "Guardar Reporte";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string filename = "Reporte de Cuadre de Caja";
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
                    string remito = "";
                    string ubicado = "";
                    string envio = "Fecha : " + +DateTime.Today.Day + "/" + DateTime.Today.Month + "/" + DateTime.Today.Year;

                    Chunk chunk = new Chunk(remito, FontFactory.GetFont("ARIAL", 16, iTextSharp.text.Font.BOLD, color: BaseColor.BLUE));
                    var fecha = new Paragraph(envio, FontFactory.GetFont("ARIAL", 8, iTextSharp.text.Font.ITALIC));
                    fecha.Alignment = Element.ALIGN_RIGHT;
                    doc.Add(fecha);
                    var chuckalign = new Paragraph(chunk);
                    chuckalign.Alignment = Element.ALIGN_CENTER;
                    doc.Add(chuckalign);
                    var ubicacionalign = new Paragraph(ubicado, FontFactory.GetFont("ARIAL", 9, iTextSharp.text.Font.NORMAL));
                    ubicacionalign.Alignment = Element.ALIGN_CENTER;
                    doc.Add(ubicacionalign);

                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Reporte de Cuadre de Caja"));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Total de Modenas de 5       : " + txtde5.Text));
                    doc.Add(new Paragraph("Total de Modenas de 10     : " + txtde10.Text));
                    doc.Add(new Paragraph("Total de Modenas de 25     : " + txtde25.Text));
                    doc.Add(new Paragraph("Total de Billetes de 50        : " + txtde50.Text));
                    doc.Add(new Paragraph("Total de Billetes de 100      : " + txtde100.Text));
                    doc.Add(new Paragraph("Total de Billetes de 200      : " + txtde200.Text));
                    doc.Add(new Paragraph("Total de Billetes de 500      : " + txtde500.Text));
                    doc.Add(new Paragraph("Total de Billetes de 1000    : " + txtde1000.Text));
                    doc.Add(new Paragraph("Total de Billetes de 2000    : " + txtde2000.Text));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph("Totales de Ingresos  : " + lblmontocaja.Text));
                    //doc.Add(new Paragraph("Totales de Ingresos  : " + lblmontoingreso.Text));
                    //doc.Add(new Paragraph("Totales de Gastos    : " + lblmontogasto.Text));
                    doc.Add(new Paragraph("Totales Final             : " + lblmontocuadre.Text));
                    //doc.Add(new Paragraph("Totales De Deudas del dia : " + lbldeudas.Text));
                    doc.Add(new Paragraph("                       "));
                    doc.Add(new Paragraph(lblmensaje.Text, FontFactory.GetFont("ARIAL", 10, iTextSharp.text.Font.NORMAL)));
                    doc.AddCreationDate();
                    doc.Close();
                    Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
                }
            }
            else
            {
                MessageBox.Show("No guardo el Archivo");
            }
        }

        private void BoxSquareForm_Load(object sender, EventArgs e)
        {
            GetAmountInBox(dpkfechacuadre.Value);
            label8.Enabled = lblmontocaja.Text == 0.ToString();
        }

        private void GetAmountInBox(DateTime datein)
        {
            var (amount, message) = salesRepository.GetAmountByDate(datein);
            if (message.Contains("Error"))
                MessageBox.Show(message);

            lblmontocaja.Text = amount.ToString();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnimprimir_Click(object sender, EventArgs e)
        {
            To_pdf();
        }
    }
}
