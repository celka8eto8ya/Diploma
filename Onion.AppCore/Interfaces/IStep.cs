using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IStep
    {
        IEnumerable<StepDTO> GetList();
        void Create(StepDTO stepDTO);
        void Update(StepDTO stepDTO);
        void Delete(int id);
        StepDTO GetById(int id);
        bool IsUniqueStep(StepDTO stepDTO);
    }
}
