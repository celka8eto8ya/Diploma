using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class EffectService : IEffect
    {
        private readonly IGenericRepository<Step> _stepRepository;
        private readonly IGenericRepository<Condition> _conditionRepository;
        private readonly IGenericRepository<ReviewStage> _reviewStageRepository;
        private readonly IGenericRepository<Task> _taskRepository;
        private readonly IGenericRepository<Effect> _effectRepository;


        public EffectService(IGenericRepository<Step> stepRepository, IGenericRepository<Condition> conditionRepository,
            IGenericRepository<ReviewStage> reviewStageRepository, IGenericRepository<Task> taskRepository,
            IGenericRepository<Effect> effectRepository)
        {
            _stepRepository = stepRepository;
            _conditionRepository = conditionRepository;
            _reviewStageRepository = reviewStageRepository;
            _taskRepository = taskRepository;

            _effectRepository = effectRepository;
        }

        public IEnumerable<EffectDTO> GetList()
            => _effectRepository.GetList().Select(x => new EffectDTO()
            {
                Id = x.Id,
                CalculateDate = x.CalculateDate,
                IRR = x.IRR,
                ROI = x.ROI,
                NPV = x.NPV,
                ETC = x.ETC,
                PCT_A = x.PCT_A,
                PCT_T = x.PCT_T,
                POT = x.POT,
                POA = x.POA,
               
                ProjectId = x.ProjectId
            });


        //public bool IsUniqueStep(StepDTO stepDTO)
        //   => _stepRepository.GetList().Any(x => x.Name == stepDTO.Name && x.Id != stepDTO.Id);


        public void Create(EffectDTO effectDTO)
           => _effectRepository.Create(new Effect()
           {
               CalculateDate = effectDTO.CalculateDate,
               IRR = effectDTO.IRR,
               ROI = effectDTO.ROI,
               NPV = effectDTO.NPV,
               ETC = effectDTO.ETC,
               PCT_A = effectDTO.PCT_A,
               PCT_T = effectDTO.PCT_T,
               POT = effectDTO.POT,
               POA = effectDTO.POA,

               ProjectId = effectDTO.ProjectId
           });


        //public void Delete(int id)
        //{
        //    if (_taskRepository.GetList().Any(x => x.StepId == id))
        //        _taskRepository.GetList().Where(x => x.StepId == id).ToList().ForEach(x => _taskRepository.Delete(x.Id));

        //    _stepRepository.Delete(id);
        //}


        //public void Update(StepDTO stepDTO)
        //    => _stepRepository.Update(new Step
        //    {
        //        Id = stepDTO.Id,
        //        Name = stepDTO.Name,
        //        Description = stepDTO.Description,
        //        TechStack = stepDTO.TechStack,
        //        TaskAmount = stepDTO.TaskAmount,
        //        PercentCompletionTasks = stepDTO.PercentCompletionTasks,
        //        AmountCompletionTasks = stepDTO.AmountCompletionTasks,

        //        ProjectId = stepDTO.ProjectId,
        //        ConditionId = stepDTO.ConditionId,
        //        ReviewStageId = stepDTO.ReviewStageId
        //    });


        //public StepDTO GetById(int id)
        //{
        //    Step step = _stepRepository.GetById(id);
        //    return new StepDTO()
        //    {
        //        Id = step.Id,
        //        Name = step.Name,
        //        Description = step.Description,
        //        TechStack = step.TechStack,
        //        TaskAmount = step.TaskAmount,
        //        PercentCompletionTasks = step.PercentCompletionTasks,
        //        AmountCompletionTasks = step.AmountCompletionTasks,

        //        ProjectId = step.ProjectId,
        //        ConditionId = step.ConditionId,
        //        ReviewStageId = step.ReviewStageId
        //    };
        //}

    }
}
