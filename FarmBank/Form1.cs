using System;
using System.Windows.Forms;
using BarnCase.Entities;
using BarnCase.UI.Controls;

namespace FarmBank
{
    public partial class Form1 : Form
    {
        private BarnControl barnControl;
        private ProductControl productControl;
        private HomeControl homeControl;

        public Form1()
        {
            InitializeComponent();

            barnControl = new BarnControl();
            productControl = new ProductControl();
            homeControl = new HomeControl();

          
            barnControl.AnimalsAdded += OnAnimalsAdded;

            ShowControl(homeControl);
            SetColor(btnHome);
        }

        private void OnAnimalsAdded()
        {
         
            bool cows = AnimalStorage.AnimalList.Any(a => a is Cow);
            bool sheep = AnimalStorage.AnimalList.Any(a => a is Sheep);
            bool chickens = AnimalStorage.AnimalList.Any(a => a is Chicken);

            productControl.SetAnimalsAdded(cows, sheep, chickens);
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
            ShowControl(homeControl);
            SetColor(btnHome);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ShowControl(productControl);
            SetColor(btnProduct);
        }

        private void btnBarn_Click(object sender, EventArgs e)
        {
            barnControl.UpdateUIFromStorage();
            ShowControl(barnControl);
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

