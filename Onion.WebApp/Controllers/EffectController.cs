using Microsoft.AspNetCore.Mvc;
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
            ////var notifications = _notificationService.GetList();


            ViewBag.Project = _projectService.GetById(id);

            double initial = 10000;
            double[] mass = { 5000, 4000, 3000, 1000, 0, 0, 0 };
            double summ;

            for (double i = 0.0001; i < 0.5; i += 0.0001)
            {
               summ = 0;
                for (int j = 0; j < mass.Length; j++)
                {
                    if (mass[j] > 0)
                    {
                        summ += mass[j] / Math.Pow(1 + i, j + 1);
                    }

                }

                if (summ < initial)
                {
                    ViewBag.IRRsumm = summ;
                    ViewBag.IRR = (i-0.0001) * 100;
                    break;
                }
            }



            //ViewBag.stepId = _taskService.GetById(id);


            ////if (User.IsInRole("ProjectManager"))
            ////    return View(notifications.Where(x => x.EmployeeId != null && x.Viewed == false && x.ProjectId == id));
            ////else
            ////{
            ////    var employeeId = _employeeService.GetByEmailEntity(User.Identity.Name);

            ////    return View(notifications.Where(x => x.EmployeeId == null && x.Viewed == false && x.ProjectId == id
            ////        && _taskService.GetById(x.TaskId).EmployeeId == employeeId));
            ////}

            return View();
        }

    }
}
