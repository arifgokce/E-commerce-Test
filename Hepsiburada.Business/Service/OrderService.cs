using Hepsiburada.Business.Interface.Services;
using Hepsiburada.DataAccess.Interface;
using Hepsiburada.Entities.EfEntities;
using System.Linq;

namespace Hepsiburada.Business.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void CreateOrder(Order order)
        {
            _orderRepository.Add(order);
        }
        public int SalesCount(int CampaignId)
        {
            return _orderRepository.Count(x => x.CampaignId == CampaignId);
        }
        public decimal SalesTotalAmount(int CampaignId)
        {
            return _orderRepository.GetList(x => x.CampaignId == CampaignId).Sum(x => x.Price);
        }

    }
}
