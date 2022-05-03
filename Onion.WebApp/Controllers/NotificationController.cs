using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.Interfaces;
using System.Linq;

namespace Onion.WebApp.Controllers
{
    public class NotificationController : Controller
    {
        private readonly IStep _stepService;
        private readonly ICondition _conditionService;
        private readonly IReviewStage _reviewStageService;
        private readonly IProject _projectService;
        private readonly INotification _notificationService;
        private readonly IEmployee _employeeService;
        private readonly ITask _taskService;

        public NotificationController(IStep stepService, ICondition conditionService, IReviewStage reviewStageService,
            IProject projectService, INotification notificationService, IEmployee employeeService, ITask taskService)
        {
            _stepService = stepService;
            _conditionService = conditionService;
            _reviewStageService = reviewStageService;
            _projectService = projectService;
            _notificationService = notificationService;
            _employeeService = employeeService;
            _taskService = taskService;
        }


        [HttpGet]
        public IActionResult Show(int id)
        {
            var notifications = _notificationService.GetList();


            ViewBag.Project = _projectService.GetById(id);
            //ViewBag.stepId = _taskService.GetById(id);


            if (User.IsInRole("ProjectManager"))
                return View(notifications.Where(x => x.EmployeeId != null && x.Viewed == false && x.ProjectId == id));
            else
            {
                var employeeId = _employeeService.GetByEmailEntity(User.Identity.Name);

                return View(notifications.Where(x => x.EmployeeId == null && x.Viewed == false && x.ProjectId == id
                    && _taskService.GetById(x.TaskId).EmployeeId == employeeId ));
            }
        }


        [HttpGet]
        public IActionResult ChangeVisible( int notificationId)
        {
            var notification = _notificationService.GetList().First(x => x.Id == notificationId);
            notification.Viewed = true;
            _notificationService.Update(notification);

            return RedirectToAction("Show", "Notification", new { id = notification.ProjectId });
        }

       

    }
}
