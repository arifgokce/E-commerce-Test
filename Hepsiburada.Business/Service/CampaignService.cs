using Hepsiburada.Business.Interface.Services;
using Hepsiburada.DataAccess.Interface;
using Hepsiburada.Entities.EfEntities;

namespace Hepsiburada.Business.Service
{
    public class CampaignService : ICampaignService
    {
        readonly private ICampaignRepository _campaignRepository;
        public CampaignService(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public void CreateCampaign(Campaign campaign)
        {
            _campaignRepository.Add(campaign);
        }

        public Campaign GetCampaignProductCode(string ProductCode)
        {
            return _campaignRepository.Get(x => x.ProductCode == ProductCode);
        }
        public Campaign GetCampaignCampaignName(string CampaignName)
        {
            return _campaignRepository.Get(x => x.Name == CampaignName);
        }

        public void UpdateCampaign(Campaign campaign)
        {
            _campaignRepository.Update(campaign);
        }
    }
}
