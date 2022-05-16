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
        private readonly IGenericRepository<PersonalFile> _personalFileRepository;


        public TaskService(IGenericRepository<Step> stepRepository, IGenericRepository<Condition> conditionRepository,
            IGenericRepository<ReviewStage> reviewStageRepository, IGenericRepository<Task> taskRepository,
             IGenericRepository<Notification> notificationRepository, IGenericRepository<PersonalFile> personalFileRepository)
        {
            _stepRepository = stepRepository;
            _conditionRepository = conditionRepository;
            _reviewStageRepository = reviewStageRepository;
            _taskRepository = taskRepository;
            _notificationRepository = notificationRepository;
            _personalFileRepository = personalFileRepository;
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


        public Task Create(TaskDTO taskDTO)
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
            return task;
        }

        public void Delete(int id)
        {
            var task = _taskRepository.GetList().First(x => x.Id == id);
            Step step = _stepRepository.GetById((int)task.StepId);
            step.TaskAmount--;
            //CalculateAVGCostComplexity(task.EmployeeId, id);
            //CalculateAVGOverdueCompletion(task.EmployeeId, id);
            CalculatePersonalFileByDelete(task.EmployeeId, id);
            _taskRepository.Delete(id);
            _stepRepository.Update(step);
        }

        public void Update(TaskDTO taskDTO)
        {
            _taskRepository.Update(new Task
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

            CalculateAVGCostComplexity(taskDTO.EmployeeId);
        }

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
            var personalFile = _personalFileRepository.GetList().First(x => x.EmployeeId == id);
            if (task.EmployeeId == null)
            {
                task.EmployeeId = id;
                task.Cost = (task.Deadline - task.CreateDate).Days / 30.0 * personalFile.AVGSalary;
            }
            else
            {
                task.ConditionId = _conditionRepository.GetList().First(x => x.Name == Enums.Conditions.ForImplementation.ToString()).Id;
                task.ReviewStageId = _reviewStageRepository.GetList().First(x => x.Name == Enums.ReviewStages.None.ToString()).Id;
                task.Cost = 0;
                task.EmployeeId = null;
            }

            _taskRepository.Update(task);

            CalculateAVGCostComplexity(id);
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

                    var completedId = _conditionRepository.GetList().First(x => x.Name == Enums.Conditions.Completed.ToString()).Id;
                    task.ConditionId = completedId;
                    var acceptedId = _reviewStageRepository.GetList().First(x => x.Name == Enums.ReviewStages.Accepted.ToString()).Id;
                    task.ReviewStageId = acceptedId;
                    task.CompletionDate = DateTime.Now;

                    CalculateAVGOverdueCompletion(task.EmployeeId);
                }
                else if (command == "Revision")
                {
                    text = $"PM \"{email}\" set condition in \"ForImplementation\". ";
                    task.ConditionId = _conditionRepository.GetList().First(x => x.Name == Enums.Conditions.ForImplementation.ToString()).Id;
                    task.ReviewStageId = _reviewStageRepository.GetList().First(x => x.Name == Enums.ReviewStages.ForRevision.ToString()).Id;
                }
            }
            else if (role == "Employee")
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
                Viewed = false,

                ProjectId = projectId,
                EmployeeId = employeeId,
                TaskId = task.Id
            });
        }

        private void CalculateAVGCostComplexity(int? employeeId)
        {
            if (employeeId != null)
            {
                var personalFile = _personalFileRepository.GetList().First(x => x.EmployeeId == employeeId);
                personalFile.AVGTaskCost = 0;
                personalFile.AVGTaskComplexity = 0;
                var tasksEmployee = _taskRepository.GetList().Where(x => x.EmployeeId == employeeId);

                var tasksEmployeeCost = tasksEmployee.Where(x => x.Cost > 0).ToList();
                tasksEmployeeCost.ForEach(y => personalFile.AVGTaskCost += y.Cost);
                if (tasksEmployeeCost.Count > 0)
                    personalFile.AVGTaskCost /= Convert.ToDouble(tasksEmployeeCost.Count);

                var tasksEmployeeComplexity = tasksEmployee.Where(x => x.Complexity > 0).ToList();
                tasksEmployeeComplexity.ForEach(y => personalFile.AVGTaskComplexity += y.Complexity);
                if (tasksEmployeeComplexity.Count > 0)
                    personalFile.AVGTaskComplexity /= Convert.ToDouble(tasksEmployeeComplexity.Count);

                _personalFileRepository.Update(personalFile);
            }
        }

        private void CalculateAVGOverdueCompletion(int? employeeId)
        {
            if (employeeId != null)
            {
                var completedId = _conditionRepository.GetList().First(x => x.Name == Enums.Conditions.Completed.ToString()).Id;
                var acceptedId = _reviewStageRepository.GetList().First(x => x.Name == Enums.ReviewStages.Accepted.ToString()).Id;

                var personalFileDTO = _personalFileRepository.GetList().First(x => x.EmployeeId == employeeId);
                var tasksEmployee = _taskRepository.GetList().Where(x => x.EmployeeId == employeeId
                    && x.ConditionId == completedId && x.ReviewStageId == acceptedId).ToList();

                personalFileDTO.SuccessTaskCompletion++;
                personalFileDTO.AVGTaskOverdueTime = 0;
                tasksEmployee.ForEach(y => personalFileDTO.AVGTaskOverdueTime += (y.CompletionDate - y.Deadline).TotalHours);
                if (tasksEmployee.Count > 0)
                    personalFileDTO.AVGTaskOverdueTime /= tasksEmployee.Count;

                personalFileDTO.AVGTaskCompletionTime = 0;
                tasksEmployee.ForEach(y => personalFileDTO.AVGTaskCompletionTime += (y.CompletionDate - y.CreateDate).TotalHours);
                if (tasksEmployee.Count > 0)
                    personalFileDTO.AVGTaskCompletionTime /= tasksEmployee.Count;

                _personalFileRepository.Update(personalFileDTO);
            }
        }

        private void CalculatePersonalFileByDelete(int? employeeId, int skip)
        {
            if (employeeId != null)
            {
                var personalFile = _personalFileRepository.GetList().First(x => x.EmployeeId == employeeId);
                personalFile.AVGTaskCost = 0;
                personalFile.AVGTaskComplexity = 0;
                var tasksEmployee = _taskRepository.GetList().Where(x => x.EmployeeId == employeeId);

                if (skip > 0)
                    tasksEmployee = tasksEmployee.Where(x => x.Id != skip);

                var tasksEmployeeCost = tasksEmployee.Where(x => x.Cost > 0).ToList();
                tasksEmployeeCost.ForEach(y => personalFile.AVGTaskCost += y.Cost);
                if (tasksEmployeeCost.Count > 0)
                    personalFile.AVGTaskCost /= Convert.ToDouble(tasksEmployeeCost.Count);

                var tasksEmployeeComplexity = tasksEmployee.Where(x => x.Complexity > 0).ToList();
                tasksEmployeeComplexity.ForEach(y => personalFile.AVGTaskComplexity += y.Complexity);
                if (tasksEmployeeComplexity.Count > 0)
                    personalFile.AVGTaskComplexity /= Convert.ToDouble(tasksEmployeeComplexity.Count);




                var completedId = _conditionRepository.GetList().First(x => x.Name == Enums.Conditions.Completed.ToString()).Id;
                var acceptedId = _reviewStageRepository.GetList().First(x => x.Name == Enums.ReviewStages.Accepted.ToString()).Id;

                var tasksEmployeeNew = _taskRepository.GetList().Where(x => x.EmployeeId == employeeId
                     && x.ConditionId == completedId && x.ReviewStageId == acceptedId).ToList();

                if (skip > 0)
                {
                    tasksEmployeeNew = tasksEmployeeNew.Where(x => x.Id != skip).ToList();
                    personalFile.SuccessTaskCompletion--;
                }
                else
                    personalFile.SuccessTaskCompletion++;

                personalFile.AVGTaskOverdueTime = 0;
                tasksEmployeeNew.ForEach(y => personalFile.AVGTaskOverdueTime += (y.CompletionDate - y.Deadline).TotalHours);
                if (tasksEmployeeNew.Count > 0)
                    personalFile.AVGTaskOverdueTime /= tasksEmployeeNew.Count;

                personalFile.AVGTaskCompletionTime = 0;
                tasksEmployeeNew.ForEach(y => personalFile.AVGTaskCompletionTime += (y.CompletionDate - y.CreateDate).TotalHours);
                if (tasksEmployeeNew.Count > 0)
                    personalFile.AVGTaskCompletionTime /= tasksEmployeeNew.Count;

                _personalFileRepository.Update(personalFile);
            }
        }
    }

}

