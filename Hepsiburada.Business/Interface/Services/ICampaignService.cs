using Hepsiburada.Entities.EfEntities;

namespace Hepsiburada.Business.Interface.Services
{
    public interface ICampaignService
    {
        void CreateCampaign(Campaign campaign);
        Campaign GetCampaignProductCode(string ProductCode);
        void UpdateCampaign(Campaign campaign);
        Campaign GetCampaignCampaignName(string CampaignName);
    }
}
