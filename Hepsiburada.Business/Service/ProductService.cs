using Hepsiburada.Business.Interface.Services;
using Hepsiburada.DataAccess.Interface;
using Hepsiburada.Entities.EfEntities;

namespace Hepsiburada.Business.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public void CreateProduct(Product product)
        {
            _productRepository.Add(product);
        }

        public Product GetProduct(int ProductId)
        {
            return _productRepository.Get(x => x.ProductId == ProductId);
        }
        public Product GetProductByCode(string ProductCode)
        {
            return _productRepository.Get(x => x.ProductCode == ProductCode);
        }
       
        public void ProductUpdate(Product product)
        {
            _productRepository.Update(product);
        }
    }
}
