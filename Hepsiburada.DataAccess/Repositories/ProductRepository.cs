using Hepsiburada.Common.EntityFremwork;
using Hepsiburada.DataAccess.EfContext;
using Hepsiburada.DataAccess.Interface;
using Hepsiburada.Entities.EfEntities;


namespace Hepsiburada.DataAccess.Repositories
{
    public class ProductRepository : EfEntityRepositoryBase<Product, HepsiContext>, IProductRepository
    {
    }
}
