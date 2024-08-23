using System;
using System.Collections.Generic;
using BarnCase.DataAccess;
using BarnCase.Entities;

namespace BarnCase.Business
{
    public class ProductService
    {
        public event Action ProductsUpdated;

        private bool _hasCows;
        private bool _hasSheep;
        private bool _hasChickens;

        // Temel üretim süreleri
        private const int BaseProductionTime = 10; // Temel üretim süresi (saniye)
        private const int ProductionDecreasePerAnimal = 1; // Hayvan başına azalan süre (saniye)

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

            // Dinamik üretim süresini hesapla
            int productionTime = CalculateDynamicProductionTime(productType);

            // İlerleme %100'ün altındaysa, ilerlemeyi güncelle
            if (progressValue < 100)
            {
                progressValue += 100 / productionTime; // İlerleme artışını dinamik üretim süresine göre ayarla
                if (progressValue >= 100)
                {
                    var quantity = ProductStorage.ProductQuantities.ContainsKey(productType)
                        ? ProductStorage.ProductQuantities[productType]
                        : 0;
                    ProductStorage.ProductQuantities[productType] = quantity + 1;
                    progressValue = 0;
                }
                ProductStorage.ProgressBars[productType] = (ProgressStatus)progressValue;
            }
        }

        // Dinamik üretim süresini hesaplar
        private int CalculateDynamicProductionTime(ProductType productType)
        {
            int animalCount = 0;
            switch (productType)
            {
                case ProductType.Milk:
                    animalCount = AnimalStorage.AnimalList.Count(a => a is Cow);
                    break;
                case ProductType.Wool:
                    animalCount = AnimalStorage.AnimalList.Count(a => a is Sheep);
                    break;
                case ProductType.Egg:
                    animalCount = AnimalStorage.AnimalList.Count(a => a is Chicken);
                    break;
            }

            // Üretim süresi, hayvan başına belirli bir süre azalır
            int dynamicTime = BaseProductionTime - (animalCount * ProductionDecreasePerAnimal);
            return Math.Max(dynamicTime, 1); // Üretim süresi en az 1 saniye olmalıdır
        }

        // Ürünü satar ve toplam satışları günceller
        public void SellProduct(ProductType productType)
        {
            if (ProductStorage.ProductQuantities.ContainsKey(productType) && ProductStorage.ProductQuantities[productType] > 0)
            {
                ProductStorage.ProductQuantities[productType]--;
                UpdateTotalSales(productType);
                ProductsUpdated?.Invoke();
            }
        }

        private void UpdateTotalSales(ProductType productType)
        {
            int price = productType switch
            {
                ProductType.Milk => 20,
                ProductType.Wool => 30,
                ProductType.Egg => 10,
                _ => 0
            };
            ProductStorage.TotalSales += price;
        }

        public Dictionary<ProductType, int> GetProductQuantities()
        {
            return ProductStorage.ProductQuantities;
        }

        public Dictionary<ProductType, ProgressStatus> GetProgressBars()
        {
            return ProductStorage.ProgressBars;
        }

        public int GetTotalSales()
        {
            return ProductStorage.TotalSales;
        }

        public void SetAnimalsAdded(bool hasCows, bool hasSheep, bool hasChickens)
        {
            _hasCows = hasCows;
            _hasSheep = hasSheep;
            _hasChickens = hasChickens;

            UpdateProductProgress();
            ProductsUpdated?.Invoke();
        }
    }
}


