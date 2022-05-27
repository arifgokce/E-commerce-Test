using Hepsiburada.Entities.EfEntities;

namespace Hepsiburada.Business.Interface.Services
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        int SalesCount(int CampaignId);
        decimal SalesTotalAmount(int CampaignId);
    }
}
