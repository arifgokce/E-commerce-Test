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
        private readonly IProductOperation _productOperation;
        private readonly IOrderService _orderService;
        public OrderOperation(IProductOperation productOperation, IOrderService orderService)
        {
            _productOperation = productOperation;
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
                _productOperation.ProductUpdate(product);
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
            Response<Product> pResult = _productOperation.GetProductByCode(ProductCode);
            if (pResult == null || !pResult.Successful)
            {
                throw new Exception("Ürün bulunamadı")
                {
                    HResult = 2
                };
            }
            if (pResult.Data.Stock <= 0)
            {
                throw new Exception("Ürün stokları tükenmiştir.")
                {
                    HResult = 3
                };
            }
            if (Quantity > pResult.Data.Stock)
            {
                throw new Exception($"Ürün stokları sipariş miktarından azdır. En fazla {pResult.Data.Stock} adet ürün siparişi verebilirsiniz.")
                {
                    HResult = 4
                };
            }
            return pResult.Data;
        }


    }
}
