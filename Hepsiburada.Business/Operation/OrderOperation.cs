using Hepsiburada.Business.Interface.Services;
using Hepsiburada.Business.ValidationRules.FluentValidation;
using Hepsiburada.Common.Validation;
using Hepsiburada.Entities.Base;
using Hepsiburada.Entities.EfEntities;
using Hepsiburada.Entities.Model;
using System;

namespace Hepsiburada.Business.Interface.Operation
{
    public class OrderOperation : IOrderOperation
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        public OrderOperation(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }
        public Response<string> CreateOrder(CreateOrderModel orderCreate)
        {
            ValidationTool.Validate(new CreateOrderModelValidator(), orderCreate);
            Product product = GetProductController(orderCreate.ProductCode, orderCreate.Quantity);
            Order order = orderCreate.ToOrder();
            order.ProductId = product.ProductId;
            order.Price = product.Price * order.Quantity;
            order.CampaignId = product.CampaignId;
            product.Stock -= order.Quantity;
            _orderService.CreateOrder(order);
            if (order.ProductId > 0)
            {
                //To-do TransactionScope
                _productService.ProductUpdate(product);
                return new Response<string>
                {
                    Message = "ok",
                    ResultCode = "0000",
                    Successful = true
                };
            }
            return new Response<string>
            {
                Message = "Siparişiniz alınamadı",
                ResultCode = "0001",
                Successful = false
            };
        }
        private Product GetProductController(string ProductCode, int Quantity)
        {
            Product product = _productService.GetProductByCode(ProductCode);
            if (product == null)
            {
                throw new Exception("Ürün bulunamadı")
                {
                    HResult = 2
                };
            }
            if (product.Stock <= 0)
            {
                throw new Exception("Ürün stokları tükenmiştir.")
                {
                    HResult = 3
                };
            }
            if (Quantity > product.Stock)
            {
                throw new Exception($"Ürün stokları sipariş miktarından azdır. En fazla {product.Stock} adet ürün siparişi verebilirsiniz.")
                {
                    HResult = 4
                };
            }
            return product;
        }


    }
}
