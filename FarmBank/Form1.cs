using System;
using System.Windows.Forms;
using System.Linq;
using BarnCase.Entities;
using BarnCase.UI.Controls;
using BarnCase.Business;
using BarnCase.DataAccess;

namespace FarmBank
{
    public partial class Form1 : Form
    {
        private AnimalServices _animalServices;
        private BarnControl _barnControl;
        private ProductControl _productControl;
        private HomeControl _homeControl;
        private ProductService _productService;

        public Form1()
        {
            InitializeComponent();

            // �nce ProductService nesnesini olu�turun
            _productService = new ProductService();

            // AnimalServices nesnesini olu�tururken ProductService nesnesini ge�in
            _animalServices = new AnimalServices(_productService);

            // BarnControl ve ProductControl nesnelerini olu�turur.
            _barnControl = new BarnControl(_animalServices);
            _productControl = new ProductControl(_productService);
            _homeControl = new HomeControl();

            // BarnControl �zerindeki AnimalsAdded olay�na yan�t olarak OnAnimalsAdded y�ntemini ba�lar.
            _barnControl.AnimalsAdded += OnAnimalsAdded;

            // Ba�lang��ta homeControl'� g�sterir ve btnHome d��mesinin rengini ayarlar.
            ShowControl(_homeControl);
            SetColor(btnHome);
        }

        private void OnAnimalsAdded()
        {
            bool cows = AnimalStorage.AnimalList.Any(a => a is Cow);
            bool sheep = AnimalStorage.AnimalList.Any(a => a is Sheep);
            bool chickens = AnimalStorage.AnimalList.Any(a => a is Chicken);

            // ProductControl �zerindeki SetAnimalsAdded metodunu �a��r�r
            _productService.SetAnimalsAdded(cows, sheep, chickens);
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
            ShowControl(_homeControl);
            SetColor(btnHome);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ShowControl(_productControl);
            SetColor(btnProduct);
        }

        private void btnBarn_Click(object sender, EventArgs e)
        {
            _barnControl.UpdateUIFromStorage();
            ShowControl(_barnControl);
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
