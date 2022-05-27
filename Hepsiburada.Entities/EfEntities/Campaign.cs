using Hepsiburada.Entities.Interface;
using System;

namespace Hepsiburada.Entities.EfEntities
{
    public class Campaign : IEntity
    {
        public int CampaignId { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int ManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public int IncreaseTime { get; set; }
        public byte Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
