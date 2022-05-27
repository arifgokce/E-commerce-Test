using Hepsiburada.Business.Interface.Operation;
using Hepsiburada.Business.Interface.Services;
using Hepsiburada.Entities.EfEntities;
using Hepsiburada.Entities.Model;
using System;

namespace Hepsiburada.Business.Operation
{
    public class IncreaseTimeOperation : IIncreaseTimeOperation
    {
        private readonly IIncreaseTimeService _increaseTimeService;
        public IncreaseTimeOperation(IIncreaseTimeService increaseTimeService)
        {
            _increaseTimeService = increaseTimeService;
        }

        public IncreaseTimeModel GetIncrease()
        {
            return new IncreaseTimeModel(_increaseTimeService.GetIncrease());
        }

        public IncreaseTimeModel UpdateIncrease(int time)
        {
            if (time == 0)
            {
                throw new Exception("Girilen değer 0 dan büyük olmalıdır")
                {
                    HResult = 9
                };
            }

            IncreaseTime increaseTime = _increaseTimeService.GetIncrease();
            
            if (increaseTime.IncreaseTimeValue + time < 0)
            {
                increaseTime.IncreaseTimeValue = 0;
            }
            else
            {
                increaseTime.IncreaseTimeValue += time;

            }
           
            _increaseTimeService.UpdateIncrease(increaseTime);
            return new IncreaseTimeModel(increaseTime);
        }
    }
}
