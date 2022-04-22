using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.WebApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly IStep _stepService;
        private readonly ICondition _conditionService;
        private readonly IReviewStage _reviewStageService;
        private readonly ITask _taskService;

        public TaskController(IStep stepService, ICondition conditionService, IReviewStage reviewStageService, ITask taskService)
        {
            _stepService = stepService;
            _conditionService = conditionService;
            _reviewStageService = reviewStageService;
            _taskService = taskService;
        }


        [HttpGet]
        public IActionResult Show(int id)
            => View(_taskService.GetList().Where(x => x.TaskDTO.StepId == id));


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.StepList = _stepService.GetList();
            return View();
        }


        [HttpPost]
        public IActionResult Create(TaskDTO taskDTO)
        {
            if (!_taskService.IsUniqueTask(taskDTO))
            {
                if (ModelState.IsValid)
                {
                    _taskService.Create(taskDTO);
                    ViewBag.CreateResult = "Task is successfully created!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Task already exists!");
            }
            ViewBag.StepList = _stepService.GetList();
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Conditions = _conditionService.GetList();
            ViewBag.ReviewStages = _reviewStageService.GetList();

            if (_taskService.GetList().Any(x => x.TaskDTO.Id == id) && id > 0)
                return View(_taskService.GetById(id));
            else
            {
                ModelState.AddModelError("", "Eror 400 - Bad Request!");
                return View();
            }
        }


        [HttpPost]
        public IActionResult Edit(TaskDTO taskDTO)
        {
            if (!_taskService.IsUniqueTask(taskDTO))
            {
                _taskService.Update(taskDTO);
                return Redirect("~/Project/Show");
            }
            else
                return View();
        }


        public IActionResult Delete(int id)
        {
            _taskService.Delete(id);
            return Redirect("~/Project/Show");
        }
    }
}
