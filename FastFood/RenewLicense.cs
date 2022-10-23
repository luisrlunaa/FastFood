using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using System;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class RenewLicense : Form
    {
        BusinessRepository businessRepository = new BusinessRepository();
        LicenseRepository licenseRepository = new LicenseRepository();
        public static RenewLicense Instance;
        public string licenceActual;
        public string newLicence;
        public bool isFromLogin = false;
        public BusinessInfo business;
        public License license;
        public RenewLicense()
        {
            InitializeComponent();
            Instance = this;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtrenovar.Text))
            {
                MessageBox.Show("Debe ingresar el Numero de Licencia para poder continuar con el proceso");
                return;
            }

            if (licenceActual == txtrenovar.Text && txtrenovar.Text != newLicence)
            {
                MessageBox.Show("Numero de Licencia No esperado");
                return;
            }

            if (txtrenovar.Text != newLicence)
            {
                MessageBox.Show("Numero de Licencia Incorrecta");
                return;
            }

            business.LicenseActual = newLicence;
            business.ExpirationDate = DateTime.Today.AddYears(1);
            var (update, message) = businessRepository.UpdateBusinessInfo(business);
            if (message.Contains("Error"))
                MessageBox.Show(message);

            if (!update)
            {
                MessageBox.Show("Hubo un problema al actualizar su contrato anual, favor ponerse en contacto con su proveedor");
                return;
            }

            var (updateL, message1) = licenseRepository.UpdateLicense(license);
            if (message1.Contains("Error"))
                MessageBox.Show(message1);

            MessageBox.Show(message);
            Hide();
            LoginForm form = new LoginForm();
            form.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if(isFromLogin)
            {
                var login = new LoginForm();
                login.Show();
                Close();
                return;
            }

            Application.Exit();
        }

        private void RenewLicense_Load(object sender, EventArgs e)
        {
            var (license, message) = licenseRepository.GetLicense();
            if (message.Contains("Error"))
                MessageBox.Show(message);

            newLicence = LicenseGenerator(license.Business, license.Provider, license.Id);
        }

        private string LicenseGenerator(string business, string provider, int licenceId)
        {
            var rnd = new Random();
            var secretWord = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 11);

            license = new License();
            license.Id = licenceId;
            license.Business = business;
            license.InitialSequence = rnd.Next(1, 1001);
            license.CentralSequence = rnd.Next(1, 1001);
            license.FinalSequence = rnd.Next(1, 1001);
            license.Provider = provider;
            license.SecretWord = secretWord;
            license.LastUpdate = DateTime.Today;

            var newlicense = license.Business
                           + license.InitialSequence.ToString()
                           + license.CentralSequence.ToString()
                           + license.Provider
                           + license.SecretWord
                           + license.FinalSequence.ToString();

            return newlicense;
        }
    }
}
