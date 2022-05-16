using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Onion.AppCore;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Onion.WebApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly IStep _stepService;
        private readonly ICondition _conditionService;
        private readonly IReviewStage _reviewStageService;
        private readonly ITask _taskService;
        private readonly IProject _projectService;
        private readonly IEmployee _employeeService;
        private readonly ITeam _teamService;
        private readonly IOperation _operationService;


        public TaskController(IStep stepService, ICondition conditionService, IReviewStage reviewStageService, ITask taskService,
             IProject projectService, IEmployee employeeService, ITeam teamService, IOperation operationService)
        {
            _stepService = stepService;
            _conditionService = conditionService;
            _reviewStageService = reviewStageService;
            _taskService = taskService;
            _projectService = projectService;
            _employeeService = employeeService;
            _teamService = teamService;
            _operationService = operationService;
        }


        [HttpGet]
        public IActionResult Show(int id, int taskId)
        {
            StepDTO currentStep = _stepService.GetById(id);
            ViewBag.projectId = (int)_projectService.GetById((int)currentStep.ProjectId).Id;
            ViewBag.Step = currentStep;
            ViewBag.taskId = taskId;

            if (User.IsInRole("Employee"))
            {
                int employeeId = _employeeService.GetByEmailEntity(User.Identity.Name);
                return View(_taskService.GetList().Where(x => x.TaskDTO.StepId == id && x.TaskDTO.EmployeeId == employeeId));
            }
            else
                return View(_taskService.GetList().Where(x => x.TaskDTO.StepId == id));
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            StepDTO currentStep = _stepService.GetById(id);
            ViewBag.projectId = (int)_projectService.GetById((int)currentStep.ProjectId).Id;
            ViewBag.Step = currentStep;
            return View();
        }


        [HttpPost]
        public IActionResult Create(TaskDTO taskDTO)
        {
            ViewBag.Step = _stepService.GetById((int)taskDTO.StepId);

            if (!_taskService.IsUniqueTask(taskDTO))
            {
                if (ModelState.IsValid)
                {
                    var task = _taskService.Create(taskDTO);
                    int projectId = (int)_stepService.GetById((int)task.StepId).ProjectId;
                    _operationService.Create(Enums.OperationTypes.Create.ToString(), Enums.ObjectNames.Task.ToString(),
                        task.Name, User.Identity.Name, projectId);
                    ViewBag.CreateResult = "Task is successfully created!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Task already exists!");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Conditions = _conditionService.GetList();
            ViewBag.ReviewStages = _reviewStageService.GetList();

            StepDTO currentStep = _stepService.GetById((int)_taskService.GetById(id).StepId);
            ViewBag.projectId = (int)_projectService.GetById((int)currentStep.ProjectId).Id;
            ViewBag.Step = currentStep;


            if (_taskService.GetList().Any(x => x.TaskDTO.Id == id) && id > 0)
                return View(_taskService.GetById(id));
            else
            {
                ModelState.AddModelError("", "Eror 400 - Bad Request!");
                return View();
            }
        }


        [HttpPost]
        public IActionResult Edit(TaskDTO taskDTO)
        {
            ViewBag.Conditions = _conditionService.GetList();
            ViewBag.ReviewStages = _reviewStageService.GetList();

            StepDTO currentStep = _stepService.GetById((int)taskDTO.StepId);
            ViewBag.projectId = (int)_projectService.GetById((int)currentStep.ProjectId).Id;
            ViewBag.Step = currentStep;

            if (!_taskService.IsUniqueTask(taskDTO))
            {
                if (ModelState.IsValid)
                {
                    _taskService.Update(taskDTO);

                    _operationService.Create(Enums.OperationTypes.Update.ToString(), Enums.ObjectNames.Task.ToString(),
                       taskDTO.Name, User.Identity.Name, ViewBag.projectId);
                    ViewBag.CreateResult = "Task is successfully edited!";
                }
                else
                {
                    IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    ModelState.AddModelError("", "Not correct data! ");
                }
            }
            else
            {
                ModelState.AddModelError("", "Task already exists!");
            }
            return View(taskDTO);
        }


        public IActionResult Delete(int id)
        {
            var task = _taskService.GetById(id);
            int projectId = (int)_stepService.GetById((int)task.StepId).ProjectId;
            _taskService.Delete(id);
            _operationService.Create(Enums.OperationTypes.Delete.ToString(), Enums.ObjectNames.Task.ToString(),
                task.Name, User.Identity.Name, projectId);
            return RedirectToAction("Show", "Task", new { id = task.StepId });
        }


        [HttpGet]
        public IActionResult Setting(int id, int stepId, int some)
        {
            EmployeeDTO currentEmployee = _employeeService.GetById(id);
            ViewBag.Employee = currentEmployee;

            ProjectDTO currentProject = _projectService.GetById(
            _teamService.GetById((int)currentEmployee.TeamId).ProjectId);
            ViewBag.Project = currentProject;

            var steps = _stepService.GetList().Where(x => x.StepDTO.ProjectId == currentProject.Id);
            ViewBag.Steps = steps;

            var firstStep = steps.FirstOrDefault();
            ViewBag.stepId = firstStep.StepDTO.Id;
            if (stepId > 0)
                ViewBag.stepId = stepId;

            var tasks = _taskService.GetList();
            return View(tasks.Where(x => x.TaskDTO.StepId == ViewBag.stepId
                && x.ConditionName != Enums.Conditions.Completed.ToString()
                    && x.ReviewStageName != Enums.ReviewStages.Accepted.ToString()
                        && (_taskService.GetById(x.TaskDTO.Id).EmployeeId == currentEmployee.Id
                            || _taskService.GetById(x.TaskDTO.Id).EmployeeId == null)));
        }


        [HttpPost]
        public IActionResult Setting(int id, int stepId)
            => RedirectToAction("Setting", "Task", new { id = id, stepId = stepId });


        public IActionResult SetTask(int id, int taskId, int stepId, string operationType)
        {
            if (taskId > 0)
                _taskService.SetTask(taskId, id);

            var task = _taskService.GetById(taskId);
            int projectId = (int)_stepService.GetById((int)task.StepId).ProjectId;
            _operationService.Create(operationType, Enums.ObjectNames.Task.ToString(),
               task.Name, User.Identity.Name, projectId);

            return RedirectToAction("Setting", "Task", new { id = id, stepId = stepId });
        }


        public IActionResult UpdateCondition(int taskId, int stepId, int projectId, string command)
        {
            string role = "";
            if (User.IsInRole("Employee"))
                role = "Employee";
            else if (User.IsInRole("ProjectManager"))
                role = "ProjectManager";

            var task = _taskService.GetById(taskId);
            _taskService.UpdateCondition(taskId, role, projectId, User.Identity.Name, command);
            _operationService.Create(command, Enums.ObjectNames.Task.ToString(),
                task.Name, User.Identity.Name, projectId);

            return RedirectToAction("Show", "Task", new { id = stepId });
        }

    }
}
