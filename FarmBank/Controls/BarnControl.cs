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
//kayıt işlemleri parametrik olarak tutulacak.

namespace BarnCase.UI.Controls
{
    public partial class BarnControl : UserControl
    {
        private List<Animal> animalList = new List<Animal>();

        public BarnControl()
        {
            InitializeComponent();
        }

        private void BarnControl_Load(object? sender, EventArgs e)
        {
            comboBox_Animal.Items.AddRange(new string[] { "Cow", "Sheep", "Chicken" });
            comboBox_Age.Items.AddRange(new string[] { "1", "2", "3", "4", "5" });

            dataGrid_Animal.Columns.Add("Name", "Name");
            dataGrid_Animal.Columns.Add("Age", "Age");
        }

        private void btn_AddList_Click(object sender, EventArgs e)
        {
            string? selectedAnimal = comboBox_Animal.SelectedItem?.ToString();
            string? selectedAge = comboBox_Age.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedAnimal) && !string.IsNullOrEmpty(selectedAge))
            {
                Animal animalToAdd;

                switch (selectedAnimal)
                {
                    case "Cow":
                        animalToAdd = new Cow { Name = selectedAnimal, Age = int.Parse(selectedAge) };
                        break;
                    case "Sheep":
                        animalToAdd = new Sheep { Name = selectedAnimal, Age = int.Parse(selectedAge) };
                        break;
                    case "Chicken":
                        animalToAdd = new Chicken { Name = selectedAnimal, Age = int.Parse(selectedAge) };
                        break;
                    default:
                        MessageBox.Show("Unknown animal type.");
                        return;
                }

                animalList.Add(animalToAdd);
                dataGrid_Animal.Rows.Add(animalToAdd.Name, animalToAdd.Age.ToString());
            }
            else
            {
                MessageBox.Show("Please choose both an animal and age.");
            }
        }
    }
}