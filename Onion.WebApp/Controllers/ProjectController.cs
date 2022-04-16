using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;

namespace Onion.WebApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProject _projectService;
        private readonly ICondition _conditionService;
        private readonly IReviewStage _reviewStageService;

        public ProjectController(IProject projectService, ICondition conditionService, IReviewStage reviewStageService)
        {
            _projectService = projectService;
            _conditionService = conditionService;
            _reviewStageService = reviewStageService;

        }


        [HttpGet]
        public IActionResult Show()
        {
            ViewBag.Conditions = _conditionService.GetList();
            ViewBag.ReviewStages = _reviewStageService.GetList();
            return View(_projectService.GetList());
        }


        [HttpGet]
        public IActionResult Create()
            => View();



        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(ProjectDTO projectDTO)
        {
            if (ModelState.IsValid)
            {
                _projectService.Create(projectDTO);
                ViewBag.CreateResult = "Project is successfully created!";
            }
            else
            {
                ModelState.AddModelError("", "Not correct data!");
                ViewBag.Message = "Not correct data!";
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
            _projectService.Update(projectDTO);
            return Redirect("~/Project/Show");
        }

        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return Redirect("~/Project/Show");
        }

    }
}
