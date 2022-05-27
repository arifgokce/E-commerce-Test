using Hepsiburada.Entities.EfEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hepsiburada.Entities.Model
{
    public class CreateCampaignModel
    {
        public CreateCampaignModel() { }
        public Campaign ToCampaign()
        {

            return new Campaign
            {
                CampaignId = this.CampaignId,
                Name = this.Name,
                ProductCode = this.ProductCode,
                Duration = this.Duration,
                ManipulationLimit = this.ManipulationLimit,
                TargetSalesCount = this.TargetSalesCount,
                Status = this.Status,
                CreateDate = this.CreateDate.HasValue ? this.CreateDate.Value : DateTime.Now,

            };
        }

        public CreateCampaignModel(Campaign campaign)
        {
            this.CampaignId = campaign.CampaignId;
            this.Name = campaign.Name;
            this.ProductCode = campaign.ProductCode;
            this.Duration = campaign.Duration;
            this.ManipulationLimit = campaign.ManipulationLimit;
            this.TargetSalesCount = campaign.TargetSalesCount;
            this.Status = campaign.Status;
            this.CreateDate = campaign.CreateDate;
        }

        [JsonIgnore]
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int ManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        [JsonIgnore]
        public byte Status { get; set; }
        [JsonIgnore]
        public DateTime? CreateDate { get; set; }
    }
}
