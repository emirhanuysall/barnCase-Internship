using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarnCase.Entities;
using BarnCase.DataAccess;
using BarnCase.Business;

namespace BarnCase.UI.Controls
{
    public partial class BarnControl : UserControl
    {
        private readonly AnimalServices _animalServices;

        // Hayvanlar eklendiğinde tetiklenecek olay.
        public event Action AnimalsAdded;

        public BarnControl(AnimalServices animalServices)
        {
            _animalServices = animalServices;
            _animalServices.AnimalsAdded += OnAnimalsAdded; // Olayın bağlı olduğu metodu ayarlar
            InitializeComponent();
        }

        // User control yüklendiğinde yapılacak işler.
        private void BarnControl_Load(object? sender, EventArgs e)
        {
            // ComboBox'lara hayvan türleri ve yaşları ekler.
            comboBox_Animal.Items.AddRange(new string[] { "Cow", "Sheep", "Chicken" });
            comboBox_Age.Items.AddRange(new string[] { "1", "2", "3", "4", "5" });

            // DataGrid'e sütun ekler.
            dataGrid_Animal.Columns.Add("Name", "Name");
            dataGrid_Animal.Columns.Add("Age", "Age");

            // Storage'dan UI güncellemesi yapar.
            UpdateUIFromStorage();
        }

        // Ekle butonuna tıklandığında yapılan işlemler.
        private void btn_AddList_Click(object sender, EventArgs e)
        {
            string? selectedAnimal = comboBox_Animal.SelectedItem?.ToString();
            string? selectedAge = comboBox_Age.SelectedItem?.ToString();

            // Hayvan ve yaş seçili mi kontrol eder.
            if (!string.IsNullOrEmpty(selectedAnimal) && !string.IsNullOrEmpty(selectedAge))
            {
                // Hayvan ekleme işlemini AnimalServices üzerinden yapar.
                _animalServices.AddAnimal(selectedAnimal, int.Parse(selectedAge));
            }
            else
            {
                // Hayvan ve yaş seçilmemişse uyarı gösterir.
                MessageBox.Show("Please choose both an animal and age.");
            }
        }

        // Hayvanlar eklendiğinde UI'yı günceller.
        private void OnAnimalsAdded()
        {
            UpdateUIFromStorage();
            AnimalsAdded?.Invoke(); // Diğer abonelere de bildirir
        }

        // Storage'da duran hayvanları UI'da gösterir.
        public void UpdateUIFromStorage()
        {
            dataGrid_Animal.Rows.Clear();

            // Her hayvan için 1 satır ekler.
            foreach (var animal in _animalServices.GetAnimals())
            {
                dataGrid_Animal.Rows.Add(animal.Name, animal.Age.ToString());
            }
        }
    }
}
