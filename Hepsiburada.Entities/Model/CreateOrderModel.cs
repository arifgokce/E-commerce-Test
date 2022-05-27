using Hepsiburada.Entities.EfEntities;
using System;
using System.Text.Json.Serialization;

namespace Hepsiburada.Entities.Model
{
    public class CreateOrderModel
    {
        public CreateOrderModel()
        {

        }
        public CreateOrderModel(Order order)
        {
            this.OrderId = order.OrderId;
            this.Quantity = order.Quantity;
            this.ProductId = order.ProductId;
            this.Price = order.Price;
            this.CrateDate = order.CrateDate;
        }
        public Order ToOrder( )
        {
            return new Order
            {
                OrderId = this.OrderId,
                Quantity = this.Quantity,
                ProductId = this.ProductId,
                Price = this.Price,
                CrateDate = this.CrateDate.HasValue ? this.CrateDate.Value : DateTime.Now,
            };

        }
        [JsonIgnore]
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public string ProductCode { get; set; }

        [JsonIgnore]
        public int ProductId { get; set; }
        [JsonIgnore]
        public decimal Price { get; set; }
        [JsonIgnore]
        public DateTime? CrateDate { get; set; }
    }
}
