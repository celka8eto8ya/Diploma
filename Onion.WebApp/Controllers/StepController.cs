﻿using Microsoft.AspNetCore.Mvc;
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
            ViewBag.ProjectList = _projectService.GetList();
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Conditions = _conditionService.GetList();
            ViewBag.ReviewStages = _reviewStageService.GetList();

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
            _stepService.Update(stepDTO);
            return Redirect("~/Project/Show");
        }

        public IActionResult Delete(int id)
        {
            _stepService.Delete(id);
            return Redirect("~/Project/Show");
        }
    }
}
