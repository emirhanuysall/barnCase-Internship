using BarnCase.UI.Controls;

namespace FarmBank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ShowControl(new HomeControl());
            SetColor(btnHome);
        }

        Color HbColor = "80808c".toHex();
        Color pbColor = "769490".toHex();
        Color BbColor = "726960".toHex();
        Color SelectedColor = "d3d3d4".toHex();

        void SetColor(Button SelectedButton)
        {
            btnHome.BackColor = HbColor;
            btnBarn.BackColor = BbColor;
            btnProduct.BackColor = pbColor;
            SelectedButton.BackColor = SelectedColor;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowControl(new HomeControl());
            SetColor(btnHome);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ShowControl(new ProductControl());
            SetColor(btnProduct);
        }

        private void btnBarn_Click(object sender, EventArgs e)
        {
            ShowControl(new BarnControl());
            SetColor(btnBarn);
        }

        private void ShowControl(UserControl control)
        {
            if (control != null)
            {
                contentPanel.Controls.Clear();
                control.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(control);
                contentPanel.BackColor = SelectedColor;
            }
            else
            {
                MessageBox.Show("Page not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
