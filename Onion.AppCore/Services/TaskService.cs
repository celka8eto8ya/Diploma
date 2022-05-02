using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class TaskService : ITask
    {
        private readonly IGenericRepository<Step> _stepRepository;
        private readonly IGenericRepository<Condition> _conditionRepository;
        private readonly IGenericRepository<ReviewStage> _reviewStageRepository;
        private readonly IGenericRepository<Task> _taskRepository;
        private readonly IGenericRepository<Notification> _notificationRepository;


        public TaskService(IGenericRepository<Step> stepRepository, IGenericRepository<Condition> conditionRepository,
            IGenericRepository<ReviewStage> reviewStageRepository, IGenericRepository<Task> taskRepository,
             IGenericRepository<Notification> notificationRepository)
        {
            _stepRepository = stepRepository;
            _conditionRepository = conditionRepository;
            _reviewStageRepository = reviewStageRepository;
            _taskRepository = taskRepository;
            _notificationRepository = notificationRepository;
        }

        public IEnumerable<FullTaskDTO> GetList()
            => _taskRepository.GetList().Select(x => new FullTaskDTO()
            {
                TaskDTO = new TaskDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Deadline = x.Deadline,
                    CreateDate = x.CreateDate,
                    UpdateDate = x.UpdateDate,
                    CompletionDate = x.CompletionDate,
                    Cost = x.Cost,
                    Comment = x.Comment,
                    Complexity = x.Complexity,

                    EmployeeId = x.EmployeeId,
                    ConditionId = x.ConditionId,
                    ReviewStageId = x.ReviewStageId,
                    StepId = x.StepId
                },
                ConditionName = _conditionRepository.GetById((int)x.ConditionId).Name,
                ReviewStageName = _reviewStageRepository.GetById((int)x.ReviewStageId).Name
            });


        public bool IsUniqueTask(TaskDTO taskDTO)
           => _taskRepository.GetList().Any(x => x.Name == taskDTO.Name && x.Id != taskDTO.Id);


        public void Create(TaskDTO taskDTO)
        {
            Task task = _taskRepository.CreateEntity(new Task()
            {
                Name = taskDTO.Name,
                Deadline = taskDTO.Deadline,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                CompletionDate = taskDTO.CompletionDate,
                Cost = 0,
                Comment = taskDTO.Comment,
                Complexity = taskDTO.Complexity,

                EmployeeId = taskDTO.EmployeeId,
                StepId = taskDTO.StepId,
                ConditionId = _conditionRepository.GetList().First(x => x.Name == Enums.Conditions.ForImplementation.ToString()).Id,
                ReviewStageId = _reviewStageRepository.GetList().First(x => x.Name == Enums.ReviewStages.None.ToString()).Id
            });
            Step step = _stepRepository.GetById((int)task.StepId);
            step.TaskAmount++;
            _stepRepository.Update(step);
        }


        public void Delete(int id)
        {
            Step step = _stepRepository.GetById((int)_taskRepository.GetById(id).StepId);
            step.TaskAmount--;
            _taskRepository.Delete(id);
            _stepRepository.Update(step);
        }


        public void Update(TaskDTO taskDTO)
            => _taskRepository.Update(new Task
            {
                Id = taskDTO.Id,
                Name = taskDTO.Name,
                Deadline = taskDTO.Deadline,
                CreateDate = taskDTO.CreateDate,
                UpdateDate = DateTime.Now,
                CompletionDate = taskDTO.CompletionDate,
                Cost = taskDTO.Cost,
                Comment = taskDTO.Comment,
                Complexity = taskDTO.Complexity,

                EmployeeId = taskDTO.EmployeeId,
                ConditionId = taskDTO.ConditionId,
                ReviewStageId = taskDTO.ReviewStageId,
                StepId = taskDTO.StepId
            });


        public TaskDTO GetById(int id)
        {
            Task task = _taskRepository.GetById(id);
            return new TaskDTO()
            {
                Id = task.Id,
                Name = task.Name,
                Deadline = task.Deadline,
                CreateDate = task.CreateDate,
                UpdateDate = task.UpdateDate,
                CompletionDate = task.CompletionDate,
                Cost = task.Cost,
                Comment = task.Comment,
                Complexity = task.Complexity,

                EmployeeId = task.EmployeeId,
                ConditionId = task.ConditionId,
                ReviewStageId = task.ReviewStageId,
                StepId = task.StepId
            };
        }

        public void SetTask(int taskId, int id)
        {
            var task = _taskRepository.GetById(taskId);
            if (task.EmployeeId == null)
                task.EmployeeId = id;
            else
                task.EmployeeId = null;

            _taskRepository.Update(task);
        }

        public void UpdateCondition(int taskId, string role, int projectId, string email, string command)
        {
            var task = _taskRepository.GetById(taskId);

            int? employeeId = null;
            string topic = "";
            string text = "";
            if (role == "ProjectManager")
            {
                topic = "Changed task condition (by PM)!";
                employeeId = null;
                if (command == "Accept")
                {
                    text = $"PM \"{email}\" set condition in \"Completed\". ";
                    task.ConditionId = _conditionRepository.GetList().First(x => x.Name == Enums.Conditions.Completed.ToString()).Id;
                    task.ReviewStageId = _reviewStageRepository.GetList().First(x => x.Name == Enums.ReviewStages.Accepted.ToString()).Id;
                }
                else if (command == "Revision")
                {
                    text = $"PM \"{email}\" set condition in \"ForImplementation\". ";
                    task.ConditionId = _conditionRepository.GetList().First(x => x.Name == Enums.Conditions.ForImplementation.ToString()).Id;
                    task.ReviewStageId = _reviewStageRepository.GetList().First(x => x.Name == Enums.ReviewStages.ForRevision.ToString()).Id;
                }
            }
            else if(role == "Employee")
            {
                employeeId = task.EmployeeId;
                task.ConditionId = _conditionRepository.GetList().First(x => x.Name == Enums.Conditions.ForConsideration.ToString()).Id;
                task.ReviewStageId = _reviewStageRepository.GetList().First(x => x.Name == Enums.ReviewStages.ForConsideration.ToString()).Id;
                topic = "Changed task condition (by Employee)!";
                text = $"Employee \"{email}\" set condition in \"ForConsideration\". ";
            }
            _taskRepository.Update(task);

            _notificationRepository.Create(new Notification()
            {
                Topic = topic,
                Text = text,
                CreateDate = DateTime.Now,

                ProjectId = projectId,
                EmployeeId = employeeId,
                TaskId = task.Id
            });
        }

    }
}
