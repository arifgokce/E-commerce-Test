using Hepsiburada.Entities.EfEntities;
using System.Text.Json.Serialization;

namespace Hepsiburada.Entities.Model
{
    public class CreateProductModel
    {
        public CreateProductModel() { }
        public CreateProductModel(Product product = null)
        {
            if (product != null)
            {
                this.Price = product.Price;
                this.ProductCode = product.ProductCode;
                this.ProductId = product.ProductId;
                this.ProductName = product.ProductName;
                this.ProductStatus = product.ProductStatus;
                this.Stock = product.Stock;
            }
        }
        public string ProductName { get; set; }
        [JsonIgnore]
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        [JsonIgnore]
        public byte ProductStatus { get; set; }

        public Product ToProduct()
        {
            return new Product
            {
                Price = this.Price,
                ProductCode = this.ProductCode,
                ProductId = this.ProductId,
                ProductName = this.ProductName,
                ProductStatus = this.ProductStatus,
                Stock = this.Stock
            };
        }
    }
}
