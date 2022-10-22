using FastFood.FastFood.Infrastructure.Constants;
using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class ClientsForm : Form
    {
        ClientsRepository cliensRepository = new ClientsRepository();
        public static ClientsForm Instance;
        public List<Client> lstClient;
        public ClientsForm()
        {
            InitializeComponent();
            Instance = this;
        }

        private void DrinkListForm_Load(object sender, EventArgs e)
        {
            var (lst, message) = cliensRepository.GetClients();
            if (message.Contains("Error"))
                MessageBox.Show(message);

            lstClient = new List<Client>();
            lstClient = lst;
            LlenarGri(lstClient);

            combo_tipo.Items.Clear();
            combo_tipo.Items.Add(IDTypeConstants.ID);
            combo_tipo.Items.Add(IDTypeConstants.PassPort);
        }

        private void btnAgregar3_Click(object sender, EventArgs e)
        {
            var client = new Client();
            if (string.IsNullOrEmpty(txtDoc.Text))
            {
                if (MessageBox.Show("¿Desea autogenerar un numero identificacion para este cliente?", "FoodShop", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    var id = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 12);
                    txtDoc.Text = id;
                }
            }

            if (lblNoDoc.Text == "id")
            {
                client.FirstName = txtFirtName.Text;
                client.LastName = txtLastName.Text;
                client.DocumentType = combo_tipo.Text;
                client.DocumentNo = txtDoc.Text;
                client.Birthday = dtpDate.Value;
                client.DateIn = DateTime.Today;

                var (add, message) = cliensRepository.AddClient(client);
                MessageBox.Show(message);
            }
            else
            {
                if (lblNoDoc.Text == txtDoc.Text)
                {
                    client.FirstName = txtFirtName.Text;
                    client.LastName = txtLastName.Text;
                    client.DocumentType = combo_tipo.Text;
                    client.DocumentNo = lblNoDoc.Text;
                    client.Birthday = dtpDate.Value;
                    client.LastUpdate = DateTime.Today;

                    var (update, message) = cliensRepository.UpdateClient(client);
                    MessageBox.Show(message);
                }
                else
                {
                    if (MessageBox.Show("¿Esta seguro desea cambiar el numero del documento de identificacion del cliente?", "FoodShop", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        client.FirstName = txtFirtName.Text;
                        client.LastName = txtLastName.Text;
                        client.DocumentType = combo_tipo.Text;
                        client.DocumentNo = txtDoc.Text;
                        client.Birthday = dtpDate.Value;
                        client.LastUpdate = DateTime.Today;

                        var (update, message) = cliensRepository.UpdateClient(client, lblNoDoc.Text);
                        MessageBox.Show(message);
                    }
                    else
                    {
                        client.FirstName = txtFirtName.Text;
                        client.LastName = txtLastName.Text;
                        client.DocumentType = combo_tipo.Text;
                        client.DocumentNo = lblNoDoc.Text;
                        client.Birthday = dtpDate.Value;
                        client.LastUpdate = DateTime.Today;

                        var (update, message) = cliensRepository.UpdateClient(client);
                        MessageBox.Show(message);
                    }
                }
            }

            var (lst, message1) = cliensRepository.GetClients();
            if (message1.Contains("Error"))
                MessageBox.Show(message1);

            lstClient = new List<Client>();
            lstClient = lst;
            LlenarGri(lstClient);
        }

        private void dgClients_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Program.CallTo) && Program.CallTo == nameof(SalesForm))
            {
                SalesForm.Instance.txtClientName.Text = dgClients.CurrentRow.Cells[0].Value.ToString(); ;
                SalesForm.Instance.txtRncCli.Text = dgClients.CurrentRow.Cells[1].Value.ToString() + " " + dgClients.CurrentRow.Cells[2].Value.ToString();

                Program.CallTo = string.Empty;

                Close();
                return;
            }

            lblNoDoc.Text = dgClients.CurrentRow.Cells[0].Value.ToString();
            if (!string.IsNullOrWhiteSpace(lblNoDoc.Text))
            {
                var (client, message) = cliensRepository.GetClientByDocumentNoOrName(lblNoDoc.Text);
                if (message.Contains("Error"))
                    MessageBox.Show(message);

                if (client != null)
                {
                    txtFirtName.Text = client.FirstName;
                    txtLastName.Text = client.LastName;
                    dtpDate.Value = client.Birthday;
                    txtDoc.Text = client.DocumentNo;
                    combo_tipo.SelectedIndex = combo_tipo.Items.IndexOf(client.DocumentType);
                }
            }
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.TextLength > 3)
            {
                var list = lstClient.Where(x => x.FirstName.Contains(txtSearch.Text) || x.LastName.Contains(txtSearch.Text) || x.DocumentNo.Contains(txtSearch.Text)).ToList();
                LlenarGri(list);
            }
            else
            {
                LlenarGri(lstClient);
            }
        }

        private void LlenarGri(List<Client> lst)
        {
            if (lst != null)
            {
                dgClients.Rows.Clear();
                for (int i = 0; i < lst.Count; i++)
                {
                    dgClients.Rows.Add();
                    dgClients.Rows[i].Cells["DocumentNo"].Value = lst[i].DocumentNo;
                    dgClients.Rows[i].Cells["Firts_Name"].Value = lst[i].FirstName;
                    dgClients.Rows[i].Cells["Last_Name"].Value = lst[i].LastName;
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblNoDoc.Text = string.Empty;
            txtFirtName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtDoc.Text = string.Empty;
        }
    }
}
