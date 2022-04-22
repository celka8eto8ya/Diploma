using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onion.AppCore.Services
{
    public class StepService : IStep
    {
        private readonly IGenericRepository<Step> _stepRepository;
        private readonly IGenericRepository<Condition> _conditionRepository;
        private readonly IGenericRepository<ReviewStage> _reviewStageRepository;


        public StepService(IGenericRepository<Step> stepRepository, IGenericRepository<Condition> conditionRepository,
            IGenericRepository<ReviewStage> reviewStageRepository)
        {
            _stepRepository = stepRepository;
            _conditionRepository = conditionRepository;
            _reviewStageRepository = reviewStageRepository;
        }

        public IEnumerable<FullStepDTO> GetList()
            => _stepRepository.GetList().Select(x => new FullStepDTO()
            {
                StepDTO = new StepDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    TechStack = x.TechStack,
                    TaskAmount = x.TaskAmount,
                    PercentCompletionTasks = x.PercentCompletionTasks,
                    AmountCompletionTasks = x.AmountCompletionTasks,

                    ProjectId = x.ProjectId,
                    ConditionId = x.ConditionId,
                    ReviewStageId = x.ReviewStageId
                },
                ConditionName = _conditionRepository.GetById((int)x.ConditionId).Name,
                ReviewStageName = _reviewStageRepository.GetById((int)x.ReviewStageId).Name
            });


        public bool IsUniqueStep(StepDTO stepDTO)
           => _stepRepository.GetList().Any(x => x.Name == stepDTO.Name && x.Id != stepDTO.Id);


        public void Create(StepDTO stepDTO)
           => _stepRepository.Create(new Step()
           {
               Name = stepDTO.Name,
               Description = stepDTO.Description,
               TechStack = stepDTO.TechStack,
               TaskAmount = 0,
               PercentCompletionTasks = 0,
               AmountCompletionTasks = 0,

               ProjectId = stepDTO.ProjectId,
               ConditionId = _conditionRepository.GetList().First(x => x.Name == Enums.Conditions.ForImplementation.ToString()).Id,
               ReviewStageId = _reviewStageRepository.GetList().First(x => x.Name == Enums.ReviewStages.None.ToString()).Id
           });

        public void Delete(int id)
            => _stepRepository.Delete(id);


        public void Update(StepDTO stepDTO)
            => _stepRepository.Update(new Step
            {
                Id = stepDTO.Id,
                Name = stepDTO.Name,
                Description = stepDTO.Description,
                TechStack = stepDTO.TechStack,
                TaskAmount = stepDTO.TaskAmount,
                PercentCompletionTasks = stepDTO.PercentCompletionTasks,
                AmountCompletionTasks = stepDTO.AmountCompletionTasks,

                ProjectId = stepDTO.ProjectId,
                ConditionId = stepDTO.ConditionId,
                ReviewStageId = stepDTO.ReviewStageId
            });


        public StepDTO GetById(int id)
        {
            Step step = _stepRepository.GetById(id);
            return new StepDTO()
            {
                Id = step.Id,
                Name = step.Name,
                Description = step.Description,
                TechStack = step.TechStack,
                TaskAmount = step.TaskAmount,
                PercentCompletionTasks = step.PercentCompletionTasks,
                AmountCompletionTasks = step.AmountCompletionTasks,

                ProjectId = step.ProjectId,
                ConditionId = step.ConditionId,
                ReviewStageId = step.ReviewStageId
            };
        }

    }
}
