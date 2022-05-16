using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IEffect
    {
        IEnumerable<EffectDTO> GetList();
        Effect Create(EffectDTO effectDTO);
        //double IRRCalculate(EffectDTO effectDTO);
        //double NPVCalculate(EffectDTO effectDTO);
        //void Update(StepDTO stepDTO);
        //void Delete(int id);
        //StepDTO GetById(int id);
        //bool IsUniqueStep(StepDTO stepDTO);
    }
}
