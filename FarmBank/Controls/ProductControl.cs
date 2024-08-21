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

namespace BarnCase.UI.Controls
{
    public partial class ProductControl : UserControl
    {
        private const int MILK_PRICE = 20;
        private const int WOOL_PRICE = 30;
        private const int EGG_PRICE = 10;

        private System.Windows.Forms.Timer progressTimer;
        private bool cowsAdded = false;
        private bool sheepAdded = false;
        private bool chickensAdded = false;

        public ProductControl()
        {
            InitializeComponent();
            InitializeDataGrid();
            InitializeTimer();
            UpdateUIFromStorage(); 
        }

        public void SetAnimalsAdded(bool cows, bool sheep, bool chickens)
        {
            cowsAdded = cows;
            sheepAdded = sheep;
            chickensAdded = chickens;
        }

        private void InitializeDataGrid()
        {
            dataGrid_Product.Columns.Clear();
            dataGrid_Product.Columns.Add("ProductName", "Product");
            dataGrid_Product.Columns.Add("ProductPrize", "Prize");
            dataGrid_Product.Columns.Add("Quantity", "Quantity");

            var sellButtonColumn = new DataGridViewButtonColumn
            {
                Name = "SellButton",
                Text = "Sell",
                UseColumnTextForButtonValue = true
            };
            dataGrid_Product.Columns.Add(sellButtonColumn);
            dataGrid_Product.Columns.Add("ProgressBar", "Production Time");
            dataGrid_Product.Rows.Add("Milk",20, 0, "Sell", 0);
            dataGrid_Product.Rows.Add("Wool",30, 0, "Sell", 0);
            dataGrid_Product.Rows.Add("Egg",10, 0, "Sell", 0);
            dataGrid_Product.CellClick += DataGrid_Product_CellClick;
            dataGrid_Product.CellPainting += DataGrid_Product_CellPainting;
        }

        private void InitializeTimer()
        {
            progressTimer = new System.Windows.Forms.Timer();
            progressTimer.Interval = 1000;
            progressTimer.Tick += ProgressTimer_Tick;
            progressTimer.Start();
        }

        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            UpdateProgressBar();
        }

        private void DataGrid_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGrid_Product.Columns["SellButton"].Index && e.RowIndex >= 0)
            {
                var row = dataGrid_Product.Rows[e.RowIndex];
                var productName = row.Cells["ProductName"].Value?.ToString();
                var quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                if (string.IsNullOrEmpty(productName) || quantity <= 0)
                {
                    MessageBox.Show("Product is out of stock or not selected.");
                    return;
                }

                row.Cells["Quantity"].Value = quantity - 1;
                ProductStorage.ProductQuantities[productName] = quantity - 1; 

                UpdateTotalSales(productName); 
            }
        }

        private void UpdateTotalSales(string productName)
        {
            int price = 0;

            switch (productName)
            {
                case "Milk":
                    price = MILK_PRICE;
                    break;
                case "Wool":
                    price = WOOL_PRICE;
                    break;
                case "Egg":
                    price = EGG_PRICE;
                    break;
            }

            ProductStorage.TotalSales += price; 
            label_Price.Text = $"Total Cash: {ProductStorage.TotalSales} £";
        }

        private void DataGrid_Product_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGrid_Product.Columns["ProgressBar"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                var progress = Convert.ToInt32(dataGrid_Product.Rows[e.RowIndex].Cells["ProgressBar"].Value);
                var rect = e.CellBounds;
                var progressBarRect = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4);

                using (var progressBarBrush = new SolidBrush(Color.LightGreen))
                {
                    e.Graphics.FillRectangle(progressBarBrush, progressBarRect.X, progressBarRect.Y,
                                             progressBarRect.Width * progress / 100, progressBarRect.Height);
                }

                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
        }

        private void UpdateProgressBar()
        {
            if (!cowsAdded && !sheepAdded && !chickensAdded)
                return; 

            foreach (DataGridViewRow row in dataGrid_Product.Rows)
            {
                var productName = row.Cells["ProductName"].Value?.ToString();

                if (string.IsNullOrEmpty(productName))
                {
                    continue; 
                }

                bool shouldUpdateProgress = false;

                switch (productName)
                {
                    case "Milk":
                        shouldUpdateProgress = cowsAdded;
                        break;
                    case "Wool":
                        shouldUpdateProgress = sheepAdded;
                        break;
                    case "Egg":
                        shouldUpdateProgress = chickensAdded;
                        break;
                }

                if (shouldUpdateProgress)
                {
                    var progress = Convert.ToInt32(row.Cells["ProgressBar"].Value);

                    if (progress >= 100)
                    {
                        var quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                        row.Cells["Quantity"].Value = quantity + 1; 
                        ProductStorage.ProductQuantities[productName] = quantity + 1; 

                        row.Cells["ProgressBar"].Value = 0; 
                    }
                    else
                    {
                        row.Cells["ProgressBar"].Value = progress + 10;
                        ProductStorage.ProgressBars[productName] = Convert.ToInt32(row.Cells["ProgressBar"].Value);
                    }
                }
            }
        }

        private void UpdateUIFromStorage()
        {
            foreach (DataGridViewRow row in dataGrid_Product.Rows)
            {
                var productName = row.Cells["ProductName"].Value?.ToString();

                if (string.IsNullOrEmpty(productName))
                {
                    continue; 
                }

                
                if (ProductStorage.ProductQuantities.ContainsKey(productName))
                {
                    row.Cells["Quantity"].Value = ProductStorage.ProductQuantities[productName];
                }

                if (ProductStorage.ProgressBars.ContainsKey(productName))
                {
                    row.Cells["ProgressBar"].Value = ProductStorage.ProgressBars[productName];
                }
            }

            label_Price.Text = $"Total Cash: {ProductStorage.TotalSales} £";
        }
    }
}




