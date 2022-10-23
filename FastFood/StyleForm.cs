using FastFood.Infrastructure.DataAccess.Repositories;
using FastFood.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class StyleForm : Form
    {
        public static StyleForm Instance;
        BusinessRepository businessRepository = new BusinessRepository();
        public SystemColor systemColor;
        public BusinessInfo businessInf;
        public StyleForm()
        {
            InitializeComponent();
            Instance = this;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StyleForm_Load(object sender, EventArgs e)
        {
            var colors = GetColorList();
            var (business, message1) = businessRepository.GetBusinessInfo(1);
            if (business == null)
                MessageBox.Show(message1);

            businessInf = new BusinessInfo();
            businessInf = business;
            systemColor = string.IsNullOrWhiteSpace(business.SystemColor)
                        ? JsonSerializer.Deserialize<SystemColor>(business.DefaultSystemColor)
                        : JsonSerializer.Deserialize<SystemColor>(business.SystemColor);

            if (colors.Any())
            {
                cbBackHome.Items.Clear();
                cbBackHomeText.Items.Clear();
                cbBackPrimary.Items.Clear();
                cbBackPrimaryText.Items.Clear();
                cbBackSecondary.Items.Clear();
                cbBackSecondaryText.Items.Clear();
                cbBackOthers.Items.Clear();
                cbBackOthersText.Items.Clear();

                cbButonBackSuccess.Items.Clear();
                cbButonBackSuccessText.Items.Clear();
                cbButonBackPrimary.Items.Clear();
                cbButonBackPrimaryText.Items.Clear();
                cbButonBackSecondary.Items.Clear();
                cbButonBackSecondaryText.Items.Clear();
                cbButonBackDanger.Items.Clear();
                cbButonBackDangerText.Items.Clear();
                cbButonBackOthers.Items.Clear();
                cbButonBackOthersText.Items.Clear();

                colors.ForEach(x => cbBackHome.Items.Add(x));
                colors.ForEach(x => cbBackHomeText.Items.Add(x));
                colors.ForEach(x => cbBackPrimary.Items.Add(x));
                colors.ForEach(x => cbBackPrimaryText.Items.Add(x));
                colors.ForEach(x => cbBackSecondary.Items.Add(x));
                colors.ForEach(x => cbBackSecondaryText.Items.Add(x));
                colors.ForEach(x => cbBackOthers.Items.Add(x));
                colors.ForEach(x => cbBackOthersText.Items.Add(x));

                colors.ForEach(x => cbButonBackSuccess.Items.Add(x));
                colors.ForEach(x => cbButonBackSuccessText.Items.Add(x));
                colors.ForEach(x => cbButonBackPrimary.Items.Add(x));
                colors.ForEach(x => cbButonBackPrimaryText.Items.Add(x));
                colors.ForEach(x => cbButonBackSecondary.Items.Add(x));
                colors.ForEach(x => cbButonBackSecondaryText.Items.Add(x));
                colors.ForEach(x => cbButonBackDanger.Items.Add(x));
                colors.ForEach(x => cbButonBackDangerText.Items.Add(x));
                colors.ForEach(x => cbButonBackOthers.Items.Add(x));
                colors.ForEach(x => cbButonBackOthersText.Items.Add(x));
            }

            if (systemColor != null && systemColor.ButtonsColor != null)
            {
                cbBackHome.SelectedIndex = cbBackHome.Items.IndexOf(systemColor.BackgroundHome);
                cbBackHomeText.SelectedIndex = cbBackHomeText.Items.IndexOf(systemColor.BackgroundHomeForeColor);
                cbBackPrimary.SelectedIndex = cbBackPrimary.Items.IndexOf(systemColor.BackgroundPrimaryWindows);
                cbBackPrimaryText.SelectedIndex = cbBackPrimaryText.Items.IndexOf(systemColor.BackgroundPrimaryWindowsForeColor);
                cbBackSecondary.SelectedIndex = cbBackSecondary.Items.IndexOf(systemColor.BackgroundSecondaryWindows);
                cbBackSecondaryText.SelectedIndex = cbBackSecondaryText.Items.IndexOf(systemColor.BackgroundSecondaryWindowsForeColor);
                cbBackOthers.SelectedIndex = cbBackOthers.Items.IndexOf(systemColor.BackgroundOthersWindows);
                cbBackOthersText.SelectedIndex = cbBackOthersText.Items.IndexOf(systemColor.BackgroundOthersWindowsForeColor);

                cbButonBackSuccess.SelectedIndex = cbButonBackSuccess.Items.IndexOf(systemColor.ButtonsColor.ButtonSuccess);
                cbButonBackSuccessText.SelectedIndex = cbButonBackSuccessText.Items.IndexOf(systemColor.ButtonsColor.ButtonSuccessForeColor);
                cbButonBackPrimary.SelectedIndex = cbButonBackPrimary.Items.IndexOf(systemColor.ButtonsColor.ButtonPrimary);
                cbButonBackPrimaryText.SelectedIndex = cbButonBackPrimaryText.Items.IndexOf(systemColor.ButtonsColor.ButtonPrimaryForeColor);
                cbButonBackSecondary.SelectedIndex = cbButonBackSecondary.Items.IndexOf(systemColor.ButtonsColor.ButtonSecundary);
                cbButonBackSecondaryText.SelectedIndex = cbButonBackSecondaryText.Items.IndexOf(systemColor.ButtonsColor.ButtonSecundary);
                cbButonBackDanger.SelectedIndex = cbButonBackDanger.Items.IndexOf(systemColor.ButtonsColor.ButtonDanger);
                cbButonBackDangerText.SelectedIndex = cbButonBackDangerText.Items.IndexOf(systemColor.ButtonsColor.ButtonDangerForeColor);
                cbButonBackOthers.SelectedIndex = cbButonBackOthers.Items.IndexOf(systemColor.ButtonsColor.OtherButtons);
                cbButonBackOthersText.SelectedIndex = cbButonBackOthersText.Items.IndexOf(systemColor.ButtonsColor.OtherButtonsForeColor);
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            systemColor = new SystemColor();
            systemColor.BackgroundHome = cbBackHome.Text;
            systemColor.BackgroundHomeForeColor = cbBackHomeText.Text;
            systemColor.BackgroundPrimaryWindows = cbBackPrimary.Text;
            systemColor.BackgroundPrimaryWindowsForeColor = cbBackPrimaryText.Text;
            systemColor.BackgroundSecondaryWindows = cbBackSecondary.Text;
            systemColor.BackgroundSecondaryWindowsForeColor = cbBackSecondaryText.Text;
            systemColor.BackgroundOthersWindows = cbBackOthers.Text;
            systemColor.BackgroundOthersWindowsForeColor = cbBackOthersText.Text;

            systemColor.ButtonsColor = new ButtonsColor();
            systemColor.ButtonsColor.ButtonSuccess = cbButonBackSuccess.Text;
            systemColor.ButtonsColor.ButtonSuccessForeColor = cbButonBackSuccessText.Text;
            systemColor.ButtonsColor.ButtonPrimary = cbButonBackPrimary.Text;
            systemColor.ButtonsColor.ButtonPrimaryForeColor = cbButonBackPrimaryText.Text;
            systemColor.ButtonsColor.ButtonSecundary = cbButonBackSecondary.Text;
            systemColor.ButtonsColor.ButtonSecundary = cbButonBackSecondaryText.Text;
            systemColor.ButtonsColor.ButtonDanger = cbButonBackDanger.Text;
            systemColor.ButtonsColor.ButtonDangerForeColor = cbButonBackDangerText.Text;
            systemColor.ButtonsColor.OtherButtons = cbButonBackOthers.Text;
            systemColor.ButtonsColor.OtherButtonsForeColor = cbButonBackOthersText.Text;

            var systemColorJson = JsonSerializer.Serialize(systemColor);
            if (ckRestoreStyle.Checked)
            {
                systemColorJson = businessInf.DefaultSystemColor;
            }

            businessInf.SystemColor = systemColorJson;
            businessInf.ExpirationDate = DateTime.Today.AddYears(1);
            var (update, message) = businessRepository.UpdateBusinessInfo(businessInf);
            if (!update)
            {
                MessageBox.Show("Hubo un problema al intentar cambiar los estilos del sistema, favor ponerse en contacto con su proveedor");
                return;
            }

            Form1.Instance = new Form1();
            ConfigurationsForm.Instance = new ConfigurationsForm();
            Form1.Instance.systemColor = systemColor;
            ConfigurationsForm.Instance.systemColor = systemColor;

            MessageBox.Show(message);
        }

        private List<string> GetColorList()
        {
            return new List<string>() {"AliceBlue",
                                       "AntiqueWhite",
                                       "Aqua",
                                       "Aquamarine",
                                       "Azure",
                                       "Beige",
                                       "Bisque",
                                       "Black",
                                       "BlanchedAlmond",
                                       "Blue",
                                       "BlueViolet",
                                       "Brown",
                                       "BurlyWood",
                                       "CadetBlue",
                                       "Chartreuse",
                                       "Chocolate",
                                       "Coral",
                                       "CornflowerBlue",
                                       "Cornsilk",
                                       "Crimson",
                                       "Cyan",
                                       "DarkBlue",
                                       "DarkCyan",
                                       "DarkGoldenrod",
                                       "DarkGray",
                                       "DarkGreen",
                                       "DarkKhaki",
                                       "DarkMagenta",
                                       "DarkOliveGreen",
                                       "DarkOrange",
                                       "DarkOrchid",
                                       "DarkRed",
                                       "DarkSalmon",
                                       "DarkSeaGreen",
                                       "DarkSlateBlue",
                                       "DarkSlateGray",
                                       "DarkTurquoise",
                                       "DarkViolet",
                                       "DeepPink",
                                       "DeepSkyBlue",
                                       "DimGray",
                                       "DodgerBlue",
                                       "Firebrick",
                                       "FloralWhite",
                                       "ForestGreen",
                                       "Fuchsia",
                                       "Gainsboro",
                                       "GhostWhite",
                                       "Gold",
                                       "Goldenrod",
                                       "Gray",
                                       "Green",
                                       "GreenYellow",
                                       "Honeydew",
                                       "HotPink",
                                       "IndianRed",
                                       "Indigo",
                                       "Ivory",
                                       "Khaki",
                                       "Lavender",
                                       "LavenderBlush",
                                       "LawnGreen",
                                       "LemonChiffon",
                                       "LightBlue",
                                       "LightCoral",
                                       "LightCyan",
                                       "LightGoldenrodYellow",
                                       "LightGray",
                                       "LightGreen",
                                       "LightPink",
                                       "LightSalmon",
                                       "LightSeaGreen",
                                       "LightSkyBlue",
                                       "LightSlateGray",
                                       "LightSteelBlue",
                                       "LightYellow",
                                       "Lime",
                                       "LimeGreen",
                                       "Linen",
                                       "Magenta",
                                       "Maroon",
                                       "MediumAquamarine",
                                       "MediumBlue",
                                       "MediumOrchid",
                                       "MediumPurple",
                                       "MediumSeaGreen",
                                       "MediumSlateBlue",
                                       "MediumSpringGreen",
                                       "MediumTurquoise",
                                       "MediumVioletRed",
                                       "MidnightBlue",
                                       "MintCream",
                                       "MistyRose",
                                       "Moccasin",
                                       "NavajoWhite",
                                       "Navy",
                                       "OldLace",
                                       "Olive",
                                       "OliveDrab",
                                       "Orange",
                                       "OrangeRed",
                                       "Orchid",
                                       "PaleGoldenrod",
                                       "PaleGreen",
                                       "PaleTurquoise",
                                       "PaleVioletRed",
                                       "PapayaWhip",
                                       "PeachPuff",
                                       "Peru",
                                       "Pink",
                                       "Plum",
                                       "PowderBlue",
                                       "Purple",
                                       "Red",
                                       "RosyBrown",
                                       "RoyalBlue",
                                       "SaddleBrown",
                                       "Salmon",
                                       "SandyBrown",
                                       "SeaGreen",
                                       "SeaShell",
                                       "Sienna",
                                       "Silver",
                                       "SkyBlue",
                                       "SlateBlue",
                                       "SlateGray",
                                       "Snow",
                                       "SpringGreen",
                                       "SteelBlue",
                                       "Tan",
                                       "Teal",
                                       "Thistle",
                                       "Tomato",
                                       "Turquoise",
                                       "Violet",
                                       "Wheat",
                                       "White",
                                       "WhiteSmoke",
                                       "Yellow",
                                       "YellowGreen",
                                       "ButtonFace",
                                       "ButtonHighlight",
                                       "ButtonShadow",
                                       "GradientActiveCaption",
                                       "GradientInactiveCaption",
                                       "MenuBar",
                                       "MenuHighlight"
            };
        }
    }
}
