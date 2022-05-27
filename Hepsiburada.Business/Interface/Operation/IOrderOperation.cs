using Hepsiburada.Entities.Base;
using Hepsiburada.Entities.Model;

namespace Hepsiburada.Business.Interface.Operation
{
    public interface IOrderOperation
    {
        Response<string> CreateOrder(CreateOrderModel orderCreate);

    }
}
