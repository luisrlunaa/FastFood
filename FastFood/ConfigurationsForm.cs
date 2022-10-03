using System.Drawing;
using System.Windows.Forms;

namespace FastFoodDemo
{
    public partial class ConfigurationsForm : Form
    {

        public ConfigurationsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            mainSubpanel.Visible = true;
            SideSubPanel.Height = button1.Height;
            SideSubPanel.Top = button1.Top;
            button1.BackColor = Color.Lavender;
            button2.BackColor = Color.White;

            loadform(new NCFForm());
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            mainSubpanel.Visible = true;
            SideSubPanel.Height = button2.Height;
            SideSubPanel.Top = button2.Top;
            button2.BackColor = Color.Lavender;
            button1.BackColor = Color.White;

            loadform(new ManagerEmployeeForm());
        }

        private void ConfigurationsForm_Load(object sender, System.EventArgs e)
        {
            mainSubpanel.Visible = true;
            if (!Program.IsAdmin)
            {
                SideSubPanel.Height = button2.Height;
                SideSubPanel.Top = button2.Top;
                button2.BackColor = Color.Lavender;
                button1.BackColor = Color.White;
                button1.Enabled = false;

                loadform(new ManagerEmployeeForm());
            }
            else
            {
                SideSubPanel.Height = button1.Height;
                SideSubPanel.Top = button1.Top;
                button1.BackColor = Color.Lavender;
                button2.BackColor = Color.White;

                loadform(new NCFForm());
            }
        }

        public void loadform(object Form)
        {
            if (this.mainSubpanel.Controls.Count > 0)
                this.mainSubpanel.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainSubpanel.Controls.Add(f);
            this.mainSubpanel.Tag = f;
            f.Show();
        }
    }
}
