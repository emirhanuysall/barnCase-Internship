using BarnCase.Entities;
using System.Collections.Generic;

namespace BarnCase.DataAccess
{
    public class ProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
}

