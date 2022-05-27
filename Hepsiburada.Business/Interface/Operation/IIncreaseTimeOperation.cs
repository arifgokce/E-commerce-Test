using Hepsiburada.Entities.EfEntities;
using Hepsiburada.Entities.Model;

namespace Hepsiburada.Business.Interface.Operation
{
    public interface IIncreaseTimeOperation
    {
        IncreaseTimeModel GetIncrease();
        IncreaseTimeModel UpdateIncrease(int time);
    }
}
