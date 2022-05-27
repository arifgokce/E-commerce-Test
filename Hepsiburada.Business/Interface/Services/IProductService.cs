using Hepsiburada.Entities.EfEntities;

namespace Hepsiburada.Business.Interface.Services
{
    public interface IProductService
    {
        Product GetProduct(int ProductId);
        void CreateProduct(Product product);
        Product GetProductByCode(string ProductCode);
        public void ProductUpdate(Product product);

    }
}
