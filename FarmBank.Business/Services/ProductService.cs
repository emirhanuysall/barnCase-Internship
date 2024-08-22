using System;
using System.Collections.Generic;
using BarnCase.DataAccess;
using BarnCase.Entities;

namespace BarnCase.Business
{
    public class ProductService
    {
        // Ürünler güncellendiğinde tetiklenen olay
        public event Action ProductsUpdated;

        private bool _hasCows;        
        private bool _hasSheep;       
        private bool _hasChickens;    

        // Ürünlerin ilerlemesini günceller
        public void UpdateProductProgress()
        {
            // İnek varsa süt ürünlerinin ilerlemesini güncelle
            if (_hasCows)
                UpdateProgress(ProductType.Milk);

            // Koyun varsa yün ürünlerinin ilerlemesini güncelle
            if (_hasSheep)
                UpdateProgress(ProductType.Wool);

            // Tavuk varsa yumurta ürünlerinin ilerlemesini güncelle
            if (_hasChickens)
                UpdateProgress(ProductType.Egg);

            // Ürünlerin güncellendiğini belirten olayı tetikleyin
            ProductsUpdated?.Invoke();
        }

        // Belirli bir ürün türü için ilerlemeyi günceller
        private void UpdateProgress(ProductType productType)
        {
            // Ürünün mevcut ilerleme durumunu al
            var progress = ProductStorage.ProgressBars.ContainsKey(productType)
                ? ProductStorage.ProgressBars[productType]
                : ProgressStatus.NotStarted;

            int progressValue = (int)progress;

            // İlerleme %100'ün altındaysa, ilerlemeyi güncelle
            if (progressValue < 100)
            {
                progressValue += 10; // Her güncellemede ilerlemeyi %10 artır
                if (progressValue >= 100)
                {
                    // Ürün tamamlandıysa miktarı artır ve ilerlemeyi sıfırla
                    var quantity = ProductStorage.ProductQuantities.ContainsKey(productType)
                        ? ProductStorage.ProductQuantities[productType]
                        : 0;
                    ProductStorage.ProductQuantities[productType] = quantity + 1;
                    progressValue = 0;
                }
                // Güncellenmiş ilerlemeyi sakla
                ProductStorage.ProgressBars[productType] = (ProgressStatus)progressValue;
            }
        }

        // Ürünü satar ve toplam satışları günceller
        public void SellProduct(ProductType productType)
        {
            // Ürünün miktarı varsa, miktarı bir azalt ve toplam satışları güncelle
            if (ProductStorage.ProductQuantities.ContainsKey(productType) && ProductStorage.ProductQuantities[productType] > 0)
            {
                ProductStorage.ProductQuantities[productType]--;
                UpdateTotalSales(productType);
                ProductsUpdated?.Invoke();
            }
        }

        // Toplam satışları günceller
        private void UpdateTotalSales(ProductType productType)
        {
            // Ürün türüne göre fiyat belirle
            int price = productType switch
            {
                ProductType.Milk => 20,
                ProductType.Wool => 30,
                ProductType.Egg => 10,
                _ => 0
            };

            // Toplam satışları artır
            ProductStorage.TotalSales += price;
        }

        // Ürün miktarlarını döner
        public Dictionary<ProductType, int> GetProductQuantities()
        {
            return ProductStorage.ProductQuantities;
        }

        // Progress bar döner
        public Dictionary<ProductType, ProgressStatus> GetProgressBars()
        {
            return ProductStorage.ProgressBars;
        }

        // Toplam satışları döner
        public int GetTotalSales()
        {
            return ProductStorage.TotalSales;
        }

        // Hayvanların varlığını ayarlar ve ilgili ilerleme durumlarını günceller
        public void SetAnimalsAdded(bool hasCows, bool hasSheep, bool hasChickens)
        {
            _hasCows = hasCows;
            _hasSheep = hasSheep;
            _hasChickens = hasChickens;

            // İlgili ürünlerin ilerlemesini başlat
            UpdateProductProgress();
            ProductsUpdated?.Invoke();
        }
    }
}
