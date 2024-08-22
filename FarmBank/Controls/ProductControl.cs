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
    public partial class ProductControl : UserControl
    {
        private const int MILK_PRICE = 20;  
        private const int WOOL_PRICE = 30; 
        private const int EGG_PRICE = 10;   

        private System.Windows.Forms.Timer progressTimer; 
        private ProductService _productService;  

        // ProductControl oluşturucu
        public ProductControl(ProductService productService)
        {
            InitializeComponent();
            _productService = productService;  
            InitializeDataGrid(); 
            InitializeTimer();  
            _productService.ProductsUpdated += UpdateUIFromService; 
            UpdateUIFromService();  
        }

        // DataGrid başlatır
        private void InitializeDataGrid()
        {
            dataGrid_Product.Columns.Clear();  
            dataGrid_Product.Columns.Add("ProductName", "Product");  
            dataGrid_Product.Columns.Add("ProductPrize", "Prize");  
            dataGrid_Product.Columns.Add("Quantity", "Quantity");  

            // Satış düğmesi sütununu ekle
            var sellButtonColumn = new DataGridViewButtonColumn
            {
                Name = "SellButton",
                Text = "Sell",
                UseColumnTextForButtonValue = true
            };
            dataGrid_Product.Columns.Add(sellButtonColumn);
            dataGrid_Product.Columns.Add("ProgressBar", "Production Time");  
            dataGrid_Product.Rows.Add("Milk", MILK_PRICE, 0, "Sell", 0); 
            dataGrid_Product.Rows.Add("Wool", WOOL_PRICE, 0, "Sell", 0); 
            dataGrid_Product.Rows.Add("Egg", EGG_PRICE, 0, "Sell", 0); 
            dataGrid_Product.CellClick += DataGrid_Product_CellClick;  
            dataGrid_Product.CellPainting += DataGrid_Product_CellPainting;  
        }

        // Zamanlayıcıyı başlatır
        private void InitializeTimer()
        {
            progressTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000  // Zamanlayıcıyı 1 saniyelik aralıklarla çalışacak şekilde ayarla
            };
            progressTimer.Tick += ProgressTimer_Tick;  // Zamanlayıcı tik olayına işleyici ekle
            progressTimer.Start();  // Zamanlayıcıyı başlat
        }

        // Zamanlayıcı tik olayında ürün ilerlemesini günceller
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            _productService.UpdateProductProgress();  // Ürün ilerlemesini güncelle
        }

        // Veri ızgarasında hücreye tıklanıldığında çalışır
        private void DataGrid_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Satış düğmesine tıklanıp tıklanmadığını kontrol et
            if (e.ColumnIndex == dataGrid_Product.Columns["SellButton"].Index && e.RowIndex >= 0)
            {
                var row = dataGrid_Product.Rows[e.RowIndex];
                var productName = row.Cells["ProductName"].Value?.ToString();

                // Ürün adını ProductType'a dönüştürmeye çalış
                if (Enum.TryParse(productName, out ProductType productType))
                {
                    _productService.SellProduct(productType);  // Ürünü sat
                }
                else
                {
                    MessageBox.Show("Invalid product type.");  // Geçersiz ürün türü uyarısı
                }
            }
        }

        // Veri ızgarasında hücre boyama olayını işler
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

        // Ürün hizmetinden UI'yi günceller
        private void UpdateUIFromService()
        {
            var quantities = _productService.GetProductQuantities();  // Ürün miktarlarını al
            var progressBars = _productService.GetProgressBars();  // Progress Bar al
            var totalSales = _productService.GetTotalSales();  // Toplam satışları al

            // Her bir veri ızgarası satırını güncelle
            foreach (DataGridViewRow row in dataGrid_Product.Rows)
            {
                var productName = row.Cells["ProductName"].Value?.ToString();

                if (Enum.TryParse(productName, out ProductType productType))
                {
                    if (quantities.ContainsKey(productType))
                    {
                        row.Cells["Quantity"].Value = quantities[productType];  // Miktarı güncelle
                    }

                    if (progressBars.ContainsKey(productType))
                    {
                        row.Cells["ProgressBar"].Value = (int)progressBars[productType];  // İlerleme çubuğunu güncelle
                    }
                }
            }

            // Toplam satışları güncelle
            label_Price.Text = $"Total Cash: {totalSales} £";
        }
    }
}