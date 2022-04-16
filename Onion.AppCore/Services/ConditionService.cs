using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class ConditionService :ICondition
    {
        private readonly IGenericRepository<Condition> _conditionRepository;

        public ConditionService(IGenericRepository<Condition> conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public IEnumerable<ConditionDTO> GetList()
        => _conditionRepository.GetList().Select(x => new ConditionDTO()
        {
            Id = x.Id,
            Name = x.Name,
            CreateDate = x.CreateDate
        });
    }
}
