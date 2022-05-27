using Hepsiburada.Business.Interface.Services;
using Hepsiburada.DataAccess.Interface;
using Hepsiburada.Entities.EfEntities;

namespace Hepsiburada.Business.Service
{
    public class IncreaseTimeService : IIncreaseTimeService
    {
        private readonly IIncreaseTimeRepository _increaseTimeRepository;

        public IncreaseTimeService(IIncreaseTimeRepository increaseTimeRepository)
        {
            _increaseTimeRepository = increaseTimeRepository;
        }
        public IncreaseTime GetIncrease()
        {
            return _increaseTimeRepository.Get(x => x.Id == 1);
        }
        public void UpdateIncrease(IncreaseTime increaseTime)
        {
            _increaseTimeRepository.Update(increaseTime);
        }
    }
}
