using BarnCase.Entities;
using BarnCase.Business.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BarnCase.Business.Services
{
    public class ProductService : IProductService
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void SellProduct(Product product)
        {
            var existingProduct = _products.FirstOrDefault(p => p.Name == product.Name);
            if (existingProduct != null)
            {
                existingProduct.Quantity -= product.Quantity;
                if (existingProduct.Quantity <= 0)
                {
                    _products.Remove(existingProduct);
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }
    }
}

