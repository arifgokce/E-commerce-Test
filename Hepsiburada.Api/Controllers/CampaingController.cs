using Hepsiburada.Business.Interface.Operation;
using Hepsiburada.Entities.Base;
using Hepsiburada.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiburada.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaingController : ControllerBase
    {
        private readonly ICampaignOperation _campaignOperation;
        public CampaingController(ICampaignOperation  campaignOperation)
        {
            _campaignOperation = campaignOperation;
        }

        [HttpPost("Create-Campaign")]
        public IActionResult CreateCampaign(CreateCampaignModel createCampaignModel)
        {
            Response<string> result = _campaignOperation.CreateCampaign(createCampaignModel);
            if (result.Successful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Get-Campaign-Info")]
        public IActionResult get_campaign_info(string campaignName)
        {
            Response<CampaignInfoModel> result = _campaignOperation.GetCampaignCampaignName(campaignName);
            if (result.Successful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
