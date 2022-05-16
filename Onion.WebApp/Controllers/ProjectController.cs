using Microsoft.AspNetCore.Mvc;
using Onion.AppCore;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Onion.WebApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProject _projectService;
        private readonly ICondition _conditionService;
        private readonly IReviewStage _reviewStageService;
        private readonly IEmployee _employeeService;
        private readonly ICustomer _customerService;
        private readonly INotification _notificationService;
        private readonly ITask _taskService;
        private readonly IOperation _operationService;

        public ProjectController(IProject projectService, ICondition conditionService, IReviewStage reviewStageService,
            IEmployee employeeService, ICustomer customerService, INotification notificationService, ITask taskService,
            IOperation operationService)
        {
            _projectService = projectService;
            _conditionService = conditionService;
            _reviewStageService = reviewStageService;
            _employeeService = employeeService;
            _customerService = customerService;
            _notificationService = notificationService;
            _taskService = taskService;
            _operationService = operationService;
        }


        [HttpGet]
        public IActionResult Show(int id)
        {
            var projects = _projectService.GetList();
            var notifications = _notificationService.GetList();

            List<int> ptojectsNotification = new List<int>();
            List<int> projectsId = projects.Select(x => x.ProjectDTO.Id).ToList();
            for (int i = 0; i < projects.Count(); i++)
            {
                ptojectsNotification.Add(notifications.Where(x => x.ProjectId == projectsId[i] && x.Text.Contains("ForConsideration") && !x.Viewed).Count());
            }
            ViewBag.NotifAmountPM = ptojectsNotification;

            if (User.IsInRole("Employee"))
            {
                var projectId = _employeeService.GetByEmail(User.Identity.Name);
                var employeeId = _employeeService.GetByEmailEntity(User.Identity.Name);

                ViewBag.NotifAmountEmployee = notifications.Where(x => x.ProjectId == projectId && x.EmployeeId == null
                    && !x.Viewed && _taskService.GetById(x.TaskId).EmployeeId == employeeId).Count();
            }

            if (User.IsInRole("Employee"))
                return View(projects.Where(x => x.ProjectDTO.Id == _employeeService.GetByEmail(User.Identity.Name)));
            if (User.IsInRole("Customer"))
                return View(projects.Where(x => x.ProjectDTO.Id == _customerService.GetByEmail(User.Identity.Name)));
            else
                return View(projects);
        }


        [HttpGet]
        public IActionResult Create()
            => View();


        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(ProjectDTO projectDTO)
        {
            if (!_projectService.IsUniqueProject(projectDTO))
            {
                if (ModelState.IsValid)
                {
                    var project = _projectService.Create(projectDTO);
                    _operationService.Create(Enums.OperationTypes.Create.ToString(), Enums.ObjectNames.Project.ToString(),
                        project.Name, User.Identity.Name, project.Id);

                    ViewBag.CreateResult = "Project is successfully created!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Project already exists!");
            }
            return View();
        }
       
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Conditions = _conditionService.GetList();
            ViewBag.ReviewStages = _reviewStageService.GetList();
            return View(_projectService.GetById(id));
        }


        [HttpPost]
        public IActionResult Edit(ProjectDTO projectDTO)
        {
            ViewBag.Conditions = _conditionService.GetList();
            ViewBag.ReviewStages = _reviewStageService.GetList();

            if (!_projectService.IsUniqueProject(projectDTO))
            {
                if (ModelState.IsValid)
                {
                    _projectService.Update(projectDTO);
                    _operationService.Create(Enums.OperationTypes.Update.ToString(), Enums.ObjectNames.Project.ToString(),
                       projectDTO.Name, User.Identity.Name, projectDTO.Id);
                    ViewBag.CreateResult = "Project is successfully edited!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Project already exists!");
            }
            return View(_projectService.GetById(projectDTO.Id));


            //_projectService.Update(projectDTO);
            //return Redirect("~/Project/Show");
        }


        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return Redirect("~/Project/Show");
        }

    }
}
