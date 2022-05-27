using Hepsiburada.Entities.Interface;
using System;

namespace Hepsiburada.Entities.EfEntities
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public DateTime CrateDate { get; set; }
        public int? CampaignId { get; set; }
    }
}
