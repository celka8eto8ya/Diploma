using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IStep
    {
        IEnumerable<FullStepDTO> GetList();
        Step Create(StepDTO stepDTO);
        void Update(StepDTO stepDTO);
        void Delete(int id);
        StepDTO GetById(int id);
        bool IsUniqueStep(StepDTO stepDTO);
    }
}
