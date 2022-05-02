using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.WebApp.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IStep _stepService;
        private readonly ICondition _conditionService;
        private readonly IReviewStage _reviewStageService;
        private readonly IProject _projectService;
        private readonly INotification _notificationService;

        public NotificationController(IStep stepService, ICondition conditionService, IReviewStage reviewStageService,
            IProject projectService, INotification notificationService)
        {
            _stepService = stepService;
            _conditionService = conditionService;
            _reviewStageService = reviewStageService;
            _projectService = projectService;
            _notificationService = notificationService;
        }


        [HttpGet]
        public IActionResult Show(int id)
        {
            var notifications = _notificationService.GetList();


            ViewBag.Project = _projectService.GetById(id);


            if (User.IsInRole("ProjectManager"))
                return View(notifications.Where(x => x.EmployeeId != null && x.Viewed == false));
            else
                return View(notifications.Where(x => x.EmployeeId == null && x.Viewed == false));
        }


        [HttpGet]
        public IActionResult ChangeVisible(int projectId, int notificationId)
        {
            var notification = _notificationService.GetById(notificationId);
            notification.Viewed = true;
            _notificationService.Update(notification);

            return RedirectToAction("Show", "Notification", new { id = projectId });
        }

       

    }
}
