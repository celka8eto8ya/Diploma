using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface ICondition
    {
        IEnumerable<ConditionDTO> GetList();
    }
}
