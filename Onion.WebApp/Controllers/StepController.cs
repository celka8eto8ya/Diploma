using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            => View(_stepService.GetList().Where(x => x.StepDTO.ProjectId == id));



        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.ProjectList = _projectService.GetList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(StepDTO stepDTO)
        {
            if (ModelState.IsValid)
            {
                _stepService.Create(stepDTO);
                ViewBag.ProjectList = _projectService.GetList();
                ViewBag.CreateResult = "Project is successfully created!";
            }
            else
            {
                ViewBag.ProjectList = _projectService.GetList();
                ModelState.AddModelError("", "Not correct data!");
                ViewBag.Message = "Not correct data!";
            }
            return View();
        }
        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    ViewBag.Conditions = _conditionService.GetList();
        //    ViewBag.ReviewStages = _reviewStageService.GetList();
        //    return View(_projectService.GetById(id));
        //}


        //[HttpPost]
        //public IActionResult Edit(ProjectDTO projectDTO)
        //{
        //    _projectService.Update(projectDTO);
        //    return Redirect("~/Project/Show");
        //}

        //public IActionResult Delete(int id)
        //{
        //    _projectService.Delete(id);
        //    return Redirect("~/Project/Show");
        //}

    }
}
