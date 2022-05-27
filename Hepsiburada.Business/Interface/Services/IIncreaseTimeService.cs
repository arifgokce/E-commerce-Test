using Hepsiburada.Entities.EfEntities;

namespace Hepsiburada.Business.Interface.Services
{
    public interface IIncreaseTimeService
    {
        IncreaseTime GetIncrease();
        void UpdateIncrease(IncreaseTime increaseTime);
    }
}
