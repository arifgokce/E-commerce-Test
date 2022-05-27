using Hepsiburada.Entities.Base;
using Hepsiburada.Entities.EfEntities;
using Hepsiburada.Entities.Model;

namespace Hepsiburada.Business.Interface.Operation
{
    public interface IProductOperation
    {
        Product GetProduct(int ProductId);
        Response<string> CreateProduct(CreateProductModel productRequest);
        Response<Product>  GetProductByCode(string ProductCode);
    }
}
