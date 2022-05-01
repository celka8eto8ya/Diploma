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


        public TaskController(IStep stepService, ICondition conditionService, IReviewStage reviewStageService, ITask taskService,
             IProject projectService, IEmployee employeeService, ITeam teamService)
        {
            _stepService = stepService;
            _conditionService = conditionService;
            _reviewStageService = reviewStageService;
            _taskService = taskService;
            _projectService = projectService;
            _employeeService = employeeService;
            _teamService = teamService;
        }


        [HttpGet]
        public IActionResult Show(int id)
        {
            StepDTO currentStep = _stepService.GetById(id);
            ViewBag.projectId = (int)_projectService.GetById((int)currentStep.ProjectId).Id;
            ViewBag.Step = currentStep;
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
                    _taskService.Create(taskDTO);
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
            int stepId = (int)_taskService.GetById(id).StepId;
            _taskService.Delete(id);
            return RedirectToAction("Show", "Task", new { id = stepId });
        }


        [HttpGet]
        public IActionResult Setting(int id, int stepId, int some)
        {
            ViewBag.Id = id;

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

            return View(_taskService.GetList().Where(x => x.TaskDTO.StepId == ViewBag.stepId));
        }


        [HttpPost]
        public IActionResult Setting(int id, int stepId)
        {
            ViewBag.Id = id;

            EmployeeDTO currentEmployee = _employeeService.GetById(id);
            ViewBag.Employee = currentEmployee;

            ProjectDTO currentProject = _projectService.GetById(
            _teamService.GetById((int)currentEmployee.TeamId).ProjectId);
            ViewBag.Project = currentProject;

            var steps = _stepService.GetList().Where(x => x.StepDTO.ProjectId == currentProject.Id);
            ViewBag.Steps = steps;

            ViewBag.stepId = stepId;
            return View(_taskService.GetList().Where(x => x.TaskDTO.StepId == stepId));
        }


        public IActionResult SetTask(int id, int taskId, int stepId)
        {
            if (taskId > 0)
            {
                _taskService.SetTask(taskId, id);
            }
            return RedirectToAction("Setting", "Task", new { id = id, stepId = stepId });
        }

    }
}
