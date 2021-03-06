using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System.Linq;

namespace Onion.WebApp.Controllers
{
    public class StepController : Controller
    {
        private readonly IStep _stepService;
        private readonly ICondition _conditionService;
        private readonly IReviewStage _reviewStageService;
        private readonly IProject _projectService;

        public StepController(IStep stepService, ICondition conditionService, IReviewStage reviewStageService,
            IProject projectService)
        {
            _stepService = stepService;
            _conditionService = conditionService;
            _reviewStageService = reviewStageService;
            _projectService = projectService;
        }


        [HttpGet]
        public IActionResult Show(int id)
        {
            ViewBag.Project = _projectService.GetById(id);
            return View(_stepService.GetList().Where(x => x.StepDTO.ProjectId == id));
        }



        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == id);
            return View();
        }


        [HttpPost]
        public IActionResult Create(StepDTO stepDTO)
        {
            ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == stepDTO.ProjectId);
            if (!_stepService.IsUniqueStep(stepDTO))
            {
                if (ModelState.IsValid)
                {
                    _stepService.Create(stepDTO);
                    ViewBag.CreateResult = "Step is successfully created!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Step already exists!");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Conditions = _conditionService.GetList();
            ViewBag.ReviewStages = _reviewStageService.GetList();
            ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == _stepService.GetById(id).ProjectId);

            if (_stepService.GetList().Any(x => x.StepDTO.Id == id) && id > 0)
                return View(_stepService.GetById(id));
            else
            {
                ModelState.AddModelError("", "Eror 400 - Bad Request!");
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(StepDTO stepDTO)
        {
            ViewBag.Conditions = _conditionService.GetList();
            ViewBag.ReviewStages = _reviewStageService.GetList();
            ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == stepDTO.ProjectId);

            if (!_stepService.IsUniqueStep(stepDTO))
            {
                if (ModelState.IsValid)
                {
                    _stepService.Update(stepDTO);
                    ViewBag.CreateResult = "Step is successfully edited!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Step already exists!");
            }
            return View(_stepService.GetById(stepDTO.Id));

        }

        public IActionResult Delete(int id)
        {
            int projectId = (int)_stepService.GetById(id).ProjectId;
            _stepService.Delete(id);
            return RedirectToAction("Show", "Step", new { id = projectId});
        }
    }
}
