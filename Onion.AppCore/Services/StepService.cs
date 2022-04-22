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
        private readonly IGenericRepository<Stepp> _stepRepository;

        public StepService(IGenericRepository<Stepp> stepRepository)
        {
            _stepRepository = stepRepository;
        }

        public IEnumerable<StepDTO> GetList()
            => _stepRepository.GetList().Select(x => new StepDTO
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
            });


        public bool IsUniqueStep(StepDTO stepDTO)
           => _stepRepository.GetList().Any(x => x.Name == stepDTO.Name && x.Id != stepDTO.Id);


        public void Create(StepDTO stepDTO)
           => _stepRepository.Create(new Stepp()
           {
               Name = stepDTO.Name,
               Description = stepDTO.Description,
               TechStack = stepDTO.TechStack,
               TaskAmount = 0,
               PercentCompletionTasks = 0,
               AmountCompletionTasks = 0,

               ProjectId = stepDTO.ProjectId,
               ConditionId = stepDTO.ConditionId,
               ReviewStageId = stepDTO.ReviewStageId
           });

        public void Delete(int id)
            => _stepRepository.Delete(id);


        public void Update(StepDTO stepDTO)
            => _stepRepository.Update(new Stepp
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
            Stepp step = _stepRepository.GetById(id);
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
