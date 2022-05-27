using Hepsiburada.Business.Interface.Operation;
using Hepsiburada.Business.Interface.Services;
using Hepsiburada.Business.ValidationRules.FluentValidation;
using Hepsiburada.Common.Validation;
using Hepsiburada.Entities.Base;
using Hepsiburada.Entities.EfEntities;
using Hepsiburada.Entities.Enum;
using Hepsiburada.Entities.Model;
using System;

namespace Hepsiburada.Business.Operation
{
    public class ProductOperation : IProductOperation
    {
        private readonly IProductService _productService;
        private readonly ICampaignService _campaignService;
        private readonly IOrderService _orderService;
        private readonly IIncreaseTimeService _increaseTimeService;

        public ProductOperation(IProductService productService,
            ICampaignService campaignService,
            IOrderService orderService,
            IIncreaseTimeService increaseTimeService)
        {
            this._productService = productService;
            this._campaignService = campaignService;
            this._orderService = orderService;
            this._increaseTimeService = increaseTimeService;
        }

        public Response<string> CreateProduct(CreateProductModel productRequest)
        {
            ValidationTool.Validate(new CreateProductModelValidator(), productRequest);
            if (_productService.GetProductByCode(productRequest.ProductCode) != null)
            {
                throw new Exception($"Bu stok kodu başka bir ürüne kayıtlı. Lütfen bilgilerinizi kontrol ediniz")
                {
                    HResult = 1
                };
            }

            Product product = productRequest.ToProduct();
            product.ProductStatus = (byte)StatusType.Active;
            _productService.CreateProduct(product);
            if (product.ProductId > 0)
            {
                return new Response<string>
                {
                    Message = "ok",
                    ResultCode = "0000",
                    Successful = true
                };
            }
            return new Response<string>
            {
                Message = "Ürün kaydı yapılamadı.",
                ResultCode = "0001",
                Successful = false
            };
        }

        public Product GetProduct(int ProductId)
        {
            return _productService.GetProduct(ProductId);
        }

        public Response<Product> GetProductByCode(string ProductCode)
        {
            Product product = _productService.GetProductByCode(ProductCode);

            if (product != null)
            {
                ProductCampaignPriceCalculation(product);
                return new Response<Product>
                {
                    Message = "ok",
                    ResultCode = "0000",
                    Successful = true,
                    Data = product
                };
            }
            return new Response<Product>
            {
                Message = "Kayıt Bulunamadı",
                ResultCode = "0001",
                Successful = false
            };
        }

        public void ProductCampaignPriceCalculation(Product product)
        {
            Campaign campaign = _campaignService.GetCampaignProductCode(product.ProductCode);
            if (campaign != null)
            {
                DateTime startDate = Convert.ToDateTime(campaign.CreateDate.ToShortDateString());
                DateTime EndDate = Convert.ToDateTime(campaign.CreateDate.ToShortDateString()).AddHours(campaign.Duration);
                if (startDate.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    IncreaseTime increaseTime = _increaseTimeService.GetIncrease();

                    if (EndDate < DateTime.Now.AddHours(increaseTime.IncreaseTimeValue))
                    {
                        return;
                    }
                    int salesCount = _orderService.SalesCount(campaign.CampaignId);
                    if (salesCount >= campaign.TargetSalesCount)
                    {
                        return;
                    }
                 
                    decimal maxDiscountAmount = ((product.Price * campaign.ManipulationLimit) / 100);
                    decimal unitDiscount = maxDiscountAmount / campaign.Duration;
                    int remainingTime = EndDate.Hour - DateTime.Now.AddHours(increaseTime.IncreaseTimeValue).Hour;
                    decimal newPrice = product.Price - (remainingTime * unitDiscount);
                    product.Price = newPrice;
                }

            }

        }
    }
}
