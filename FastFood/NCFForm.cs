﻿using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using FastFoodDemo.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class NCFForm : Form
    {
        public static NCFForm Instance;
        NcfRepository ncfRepository = new NcfRepository();
        public NCFForm()
        {
            InitializeComponent();
            Instance = this;
        }

        private void data_ncf_DoubleClick(object sender, EventArgs e)
        {
            seleccion_data();
        }

        public void seleccion_data()
        {
            txtid.Text = data_ncf.CurrentRow.Cells[0].Value.ToString();
            lblcomp.Text = data_ncf.CurrentRow.Cells[1].Value.ToString();

            if (txtid.Text != "")
            {
                int id = Convert.ToInt32(txtid.Text);
                llenardatoscomprobantes(id);
            }
        }

        public void llenardatoscomprobantes(int id)
        {
            var (ncf, message) = ncfRepository.GetReceiptsbyId(id);
            if (message.Contains("Error"))
                MessageBox.Show(message);

            txtfinal.Text = Convert.ToString(ncf.Finalsequence);
            txtinicio.Text = Convert.ToString(ncf.Initialsequence);
            dtpinicio.Value = ncf.DateFrom;
            dtpfinal.Value = ncf.DateTo;
        }

        public void llenar_data_ncf()
        {
            var (lst, message) = ncfRepository.GetNCFActives();
            if (message.Contains("Error"))
                MessageBox.Show(message);

            if (lst != null)
            {
                data_comprobante.Rows.Clear();
                for (int i = 0; i < lst.Count; i++)
                {
                    data_ncf.Rows.Add();
                    data_ncf.Rows[i].Cells["id_ncf"].Value = lst[i].Id_ncf;
                    data_ncf.Rows[i].Cells["Description_ncf"].Value = lst[i].Description_ncf;
                    if (lst[i].Active)
                    {
                        data_ncf.Rows[i].Cells["Active"].Value = "Si";
                    }
                    else
                    {
                        data_ncf.Rows[i].Cells["Active"].Value = "No";
                    }
                }
            }
        }

        public void llenar_data_comprobante()
        {
            var (lst, message) = ncfRepository.GetReceipts();
            if (message.Contains("Error"))
                MessageBox.Show(message);

            if (lst != null)
            {
                data_comprobante.Rows.Clear();
                for (int i = 0; i < lst.Count; i++)
                {
                    if (lst[i].DateTo.Date < DateTime.Today.Date)
                    {
                        lst[i].Active = false;
                        var (update, message1) = ncfRepository.UpdateReceipts(lst[i]);
                    }

                    data_comprobante.Rows.Add();
                    data_comprobante.Rows[i].Cells["Ncf_id"].Value = lst[i].Id_ncf;
                    data_comprobante.Rows[i].Cells["Initialsequence"].Value = lst[i].Initialsequence;
                    data_comprobante.Rows[i].Cells["Finalsequence"].Value = lst[i].Finalsequence;
                    data_comprobante.Rows[i].Cells["DateFrom"].Value = lst[i].DateFrom;
                    data_comprobante.Rows[i].Cells["DateTo"].Value = lst[i].DateTo;
                }
            }
        }

        private void data_ncf_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.data_ncf.Columns[e.ColumnIndex].Name == "Active")
            {
                if (Convert.ToString(e.Value) == "No")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.Red;
                }

                if (Convert.ToString(e.Value) == "Si")
                {
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.BackColor = Color.White;
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtinicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void txtfinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.solonumeros(e);
        }

        private void NCFForm_Load(object sender, EventArgs e)
        {
            ncfRepository.CheckInActiveReceipts();
            ncfRepository.CheckActiveReceipts();

            llenar_data_ncf();
            llenar_data_comprobante();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            var receipt = new Receipts
            {
                Id_ncf = Convert.ToInt32(txtid.Text),
                Initialsequence = Convert.ToInt32(txtinicio.Text),
                Finalsequence = Convert.ToInt32(txtfinal.Text),
                DateFrom = Convert.ToDateTime(dtpinicio.Text),
                DateTo = Convert.ToDateTime(dtpfinal.Text),
                Active = Convert.ToDateTime(dtpfinal.Text).Date > DateTime.Today.Date && Convert.ToInt32(txtfinal.Text) > Convert.ToInt32(txtinicio.Text)
            };

            var (update, message) = ncfRepository.UpdateReceipts(receipt);
            if (message.Contains("Error"))
                MessageBox.Show(message);

            if (update)
            {

                var ncf = new NCF
                {
                    Id_ncf = Convert.ToInt32(txtid.Text),
                    Initialsequence = Convert.ToInt32(txtinicio.Text),
                    Finalsequence = Convert.ToInt32(txtfinal.Text)
                };

                var (save, message1) = ncfRepository.UpdateNCF(ncf);
                if (message1.Contains("Error"))
                    MessageBox.Show(message1);

                if (save)
                    MessageBox.Show(message1);
            }

            llenar_data_ncf();
            llenar_data_comprobante();
        }
    }
}
