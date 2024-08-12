using BarnCase.Entities;

namespace BarnCase.Business.Interfaces
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void SellProduct(Product product);
        IEnumerable<Product> GetProducts();
    }
}


