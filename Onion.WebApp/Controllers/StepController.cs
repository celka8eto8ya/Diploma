using Microsoft.AspNetCore.Mvc;
using Onion.AppCore;
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
        private readonly IOperation _operationService;

        public StepController(IStep stepService, ICondition conditionService, IReviewStage reviewStageService,
            IProject projectService, IOperation operationService)
        {
            _stepService = stepService;
            _conditionService = conditionService;
            _reviewStageService = reviewStageService;
            _projectService = projectService;
            _operationService = operationService;
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
                    var step = _stepService.Create(stepDTO);
                    _operationService.Create(Enums.OperationTypes.Create.ToString(), Enums.ObjectNames.Step.ToString(),
                       step.Name, User.Identity.Name, (int)step.ProjectId);
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
                    _operationService.Create(Enums.OperationTypes.Update.ToString(), Enums.ObjectNames.Step.ToString(),
                      stepDTO.Name, User.Identity.Name, (int)stepDTO.ProjectId);
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
            var stepDTO = _stepService.GetById(id);
            _stepService.Delete(id);
            _operationService.Create(Enums.OperationTypes.Delete.ToString(), Enums.ObjectNames.Step.ToString(),
                    stepDTO.Name, User.Identity.Name, (int)stepDTO.ProjectId);
            return RedirectToAction("Show", "Step", new { id = stepDTO .ProjectId});
        }
    }
}
