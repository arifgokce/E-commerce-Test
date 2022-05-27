using Hepsiburada.Entities.Interface;

namespace Hepsiburada.Entities.EfEntities
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public byte ProductStatus { get; set; }
        public int? CampaignId { get; set; }
    }
}
