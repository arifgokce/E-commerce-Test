using Hepsiburada.Business.Interface.Operation;
using Hepsiburada.Business.Interface.Services;
using Hepsiburada.Business.ValidationRules.FluentValidation;
using Hepsiburada.Common.Validation;
using Hepsiburada.Entities.Base;
using Hepsiburada.Entities.EfEntities;
using Hepsiburada.Entities.Enum;
using Hepsiburada.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.Business.Operation
{
    public class CampaignOperation : ICampaignOperation
    {
        private readonly ICampaignService _campaignService;
        private readonly IProductService _productService;
        private readonly IIncreaseTimeService _increaseTimeService;
        private readonly IOrderService _orderService;
        public CampaignOperation(ICampaignService campaignService,
            IProductService productService,
             IIncreaseTimeService increaseTimeService,
             IOrderService orderService)
        {
            _productService = productService;
            _campaignService = campaignService;
            _increaseTimeService = increaseTimeService;
            _orderService = orderService;
        }
        public Response<string> CreateCampaign(CreateCampaignModel createCampaignModel)
        {
            ValidationTool.Validate(new CreateCampaignModelValidator(), createCampaignModel);
            Campaign campaign = createCampaignModel.ToCampaign();

            CampaignNameController(createCampaignModel.Name);

            Product product = GetProductController(campaign.ProductCode);
            campaign.Status = (byte)StatusType.Active;
            _campaignService.CreateCampaign(campaign);
            if (campaign.CampaignId > 0)
            {
                product.CampaignId = campaign.CampaignId;
                _productService.ProductUpdate(product);
                return new Response<string> { Message = "ok", ResultCode = "0000", Successful = true };
            }
            return new Response<string> { Message = "Kampanya oluşturulamadı", ResultCode = "0001", Successful = false };
        }
        private Product GetProductController(string ProductCode)
        {
            Product product = _productService.GetProductByCode(ProductCode);
            if (product == null)
            {
                throw new Exception("Ürün bulunamadı")
                {
                    HResult = 5
                };
            }
            if (product.Stock <= 0)
            {
                throw new Exception("Ürün stokları tükenmiştir.")
                {
                    HResult = 6
                };
            }
            return product;
        }
        private void CampaignNameController(string CampaignName)
        {
            Campaign campaign = _campaignService.GetCampaignCampaignName(CampaignName);

            if (campaign != null)
            {
                throw new Exception("Bu kampanya adı kullanımdadır.")
                {
                    HResult = 7
                };
            }

        }

        public Response<CampaignInfoModel> GetCampaignCampaignName(string CampaignName)
        {
            Campaign campaign = _campaignService.GetCampaignCampaignName(CampaignName);
            if (campaign != null)
            {
                CampaignInfoModel campaignInfoModel = GetCampaingControl(campaign);
                return new Response<CampaignInfoModel>
                {
                    Data = campaignInfoModel,
                    ResultCode = "0000",
                    Message = "ok",
                    Successful = true
                };
            }
            return new Response<CampaignInfoModel> { ResultCode = "0001", Message = "Kampanya bulunamadı" };
        }

        private CampaignInfoModel GetCampaingControl(Campaign campaign)
        {
            CampaignInfoModel campaignInfoModel = new CampaignInfoModel();
            int salesCount = _orderService.SalesCount(campaign.CampaignId);
            decimal Turnover = _orderService.SalesTotalAmount(campaign.CampaignId);

            campaignInfoModel.TargetSales = campaign.TargetSalesCount;
            campaignInfoModel.TotalSales = salesCount;
            campaignInfoModel.Turnover = Turnover;
            if (campaignInfoModel.TotalSales > 0)
            {
                campaignInfoModel.AverageItemPrice = campaignInfoModel.Turnover / campaignInfoModel.TotalSales;
            }


            DateTime startDate = Convert.ToDateTime(campaign.CreateDate.ToShortDateString());
            DateTime EndDate = Convert.ToDateTime(campaign.CreateDate.ToShortDateString()).AddHours(campaign.Duration);

            IncreaseTime increaseTime = _increaseTimeService.GetIncrease();

            if (EndDate < DateTime.Now.AddHours(increaseTime.IncreaseTimeValue)
                || salesCount >= campaign.TargetSalesCount)
            {
                campaignInfoModel.Status = "Ended";
            }
            else
            {
                campaignInfoModel.Status = "Active";
            }

            return campaignInfoModel;
        }
    }
}
