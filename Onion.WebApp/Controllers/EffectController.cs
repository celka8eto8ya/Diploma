using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System;
using System.Linq;

namespace Onion.WebApp.Controllers
{
    public class EffectController : Controller
    {
        private readonly IStep _stepService;
        private readonly ICondition _conditionService;
        private readonly IReviewStage _reviewStageService;
        private readonly IProject _projectService;
        private readonly INotification _notificationService;
        private readonly IEmployee _employeeService;
        private readonly ITask _taskService;
        
        private readonly IEffect _effectService;

        public EffectController(IStep stepService, ICondition conditionService, IReviewStage reviewStageService,
            IProject projectService, INotification notificationService, IEmployee employeeService, ITask taskService,
            IEffect effectService)
        {
            _stepService = stepService;
            _conditionService = conditionService;
            _reviewStageService = reviewStageService;
            _projectService = projectService;
            _notificationService = notificationService;
            _employeeService = employeeService;
            _taskService = taskService;

            _effectService = effectService;
        }


        [HttpGet]
        public IActionResult Show(int id)
        {
            ViewBag.Project = _projectService.GetById(id);
            ViewBag.EffectDTO = _effectService.GetList().Last();

            return View();
        }

        [HttpPost]
        public IActionResult Show(int id, EffectDTO effectDTO)
        {
            _effectService.Create(effectDTO);

            ViewBag.EffectDTO = _effectService.GetList().Last();
            ViewBag.Project = _projectService.GetById(id);

            return View();
        }

        [HttpGet]
        public IActionResult History(int id)
        {
            ViewBag.Project = _projectService.GetById(id);

            return View(_effectService.GetList().Where(x=> x.ProjectId == id));
        }



    }
}
