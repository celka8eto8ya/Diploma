using Microsoft.AspNetCore.Mvc;
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

        public ProjectController(IProject projectService, ICondition conditionService, IReviewStage reviewStageService,
            IEmployee employeeService, ICustomer customerService, INotification notificationService)
        {
            _projectService = projectService;
            _conditionService = conditionService;
            _reviewStageService = reviewStageService;
            _employeeService = employeeService;
            _customerService = customerService;
            _notificationService = notificationService;
        }


        [HttpGet]
        public IActionResult Show()
        {
            var projects = _projectService.GetList();
            var notifications = _notificationService.GetList();

            List<int> ptojectsNotification = new List<int>();
            List<int> projectsId = projects.Select(x => x.ProjectDTO.Id).ToList();
            for (int i=0; i<projects.Count(); i++) 
            {
                ptojectsNotification.Add(notifications.Where(x => x.ProjectId == projectsId[i] && x.Text.Contains("ForConsideration")).Count());
            }
            ViewBag.NotifAmountPM = ptojectsNotification;

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
                    _projectService.Create(projectDTO);
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
