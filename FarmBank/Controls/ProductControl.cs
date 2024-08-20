using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarnCase.UI.Controls
{
    public partial class ProductControl : UserControl
    {
        private const int MILK_PRICE = 20;
        private const int WOOL_PRICE = 30;
        private const int EGG_PRICE = 10;

        private System.Windows.Forms.Timer progressTimer; 

        public ProductControl()
        {
            InitializeComponent();
            InitializeDataGrid();
            InitializeTimer();
        }

        private void InitializeDataGrid()
        {
            dataGrid_Product.Columns.Clear();
            dataGrid_Product.Columns.Add("ProductName", "Product");
            dataGrid_Product.Columns.Add("Quantity", "Quantity");

            var sellButtonColumn = new DataGridViewButtonColumn
            {
                Name = "SellButton",
                Text = "Sell",
                UseColumnTextForButtonValue = true
            };
            dataGrid_Product.Columns.Add(sellButtonColumn);            
            dataGrid_Product.Columns.Add("ProgressBar", "Production Time");
            dataGrid_Product.Rows.Add("Milk", 0, "Sell", 0);
            dataGrid_Product.Rows.Add("Wool", 0, "Sell", 0);
            dataGrid_Product.Rows.Add("Egg", 0, "Sell", 0);
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
                var productName = row.Cells["ProductName"].Value.ToString();
                var quantity = Convert.ToInt32(row.Cells["Quantity"].Value);

                if (quantity > 0)
                {
                   
                    row.Cells["Quantity"].Value = quantity - 1;
                    UpdatePriceLabel(productName);
                }
            }
        }

        private void UpdatePriceLabel(string productName)
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

            label_Price.Text = $"Fiyat: {price} birim";
        }

        private void DataGrid_Product_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dataGrid_Product.Columns["ProgressBar"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.ClipBounds, true);

                var progress = Convert.ToInt32(dataGrid_Product.Rows[e.RowIndex].Cells["ProgressBar"].Value);
                var rect = e.CellBounds;
                var progressBarRect = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height - 4);

                using (var progressBarBrush = new SolidBrush(Color.Blue))
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
            foreach (DataGridViewRow row in dataGrid_Product.Rows)
            {
                var progress = Convert.ToInt32(row.Cells["ProgressBar"].Value);

                if (progress >= 100)
                {
                    var quantity = Convert.ToInt32(row.Cells["Quantity"].Value);
                    row.Cells["Quantity"].Value = quantity + 1;
                    row.Cells["ProgressBar"].Value = 0; 
                }
                else
                {
                    row.Cells["ProgressBar"].Value = progress + 10; 
                }
            }
        }
    }
}