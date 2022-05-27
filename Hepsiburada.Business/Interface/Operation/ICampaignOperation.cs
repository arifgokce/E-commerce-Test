using Hepsiburada.Entities.Base;
using Hepsiburada.Entities.EfEntities;
using Hepsiburada.Entities.Model;

namespace Hepsiburada.Business.Interface.Operation
{
    public interface ICampaignOperation
    {
        Response<string> CreateCampaign(CreateCampaignModel createCampaignModel);
        Response<CampaignInfoModel> GetCampaignCampaignName(string CampaignName);    
    }
}
