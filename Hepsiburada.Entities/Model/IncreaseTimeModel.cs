using Hepsiburada.Entities.EfEntities;

namespace Hepsiburada.Entities.Model
{
    public class IncreaseTimeModel
    {
        public IncreaseTimeModel(IncreaseTime increaseTime)
        {
            this.Time = increaseTime.IncreaseTimeValue.ToString().PadLeft(2, '0')+":00";
        }
        public string Time { get; set; }
    }
}
