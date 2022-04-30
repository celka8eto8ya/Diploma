using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.WebApp.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocument _documentService;
        private readonly IProject _projectService;

        public DocumentController(IDocument documentService, IProject projectService)
        {
            _documentService = documentService;
            _projectService = projectService;
        }


        [HttpGet]
        public IActionResult Show(int id)
        {
            ViewBag.Project = _projectService.GetById(id);
            return View(_documentService.GetList().Where(x => x.ProjectId == id));
        }



        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == id);
            return View();
        }


        [HttpPost]
        public IActionResult Create(DocumentDTO documentDTO)
        {
            ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == documentDTO.ProjectId);
           
            if (!_documentService.IsUnique(documentDTO))
            {
                if (ModelState.IsValid)
                {
                    _documentService.Create(documentDTO);
                    ViewBag.CreateResult = "Document is successfully created!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Document already exists!");
            }
            return View();
        }


        ////[HttpGet]
        ////public IActionResult Edit(int id)
        ////{
        ////    ViewBag.Conditions = _conditionService.GetList();
        ////    ViewBag.ReviewStages = _reviewStageService.GetList();
        ////    ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == _stepService.GetById(id).ProjectId);

        ////    if (_stepService.GetList().Any(x => x.StepDTO.Id == id) && id > 0)
        ////        return View(_stepService.GetById(id));
        ////    else
        ////    {
        ////        ModelState.AddModelError("", "Eror 400 - Bad Request!");
        ////        return View();
        ////    }
        ////}

        ////[HttpPost]
        ////public IActionResult Edit(StepDTO stepDTO)
        ////{
        ////    ViewBag.Conditions = _conditionService.GetList();
        ////    ViewBag.ReviewStages = _reviewStageService.GetList();
        ////    ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == stepDTO.ProjectId);

        ////    if (!_stepService.IsUniqueStep(stepDTO))
        ////    {
        ////        if (ModelState.IsValid)
        ////        {
        ////            _stepService.Update(stepDTO);
        ////            ViewBag.CreateResult = "Step is successfully edited!";
        ////        }
        ////        else
        ////        {
        ////            ModelState.AddModelError("", "Not correct data!");
        ////        }
        ////    }
        ////    else
        ////    {
        ////        ModelState.AddModelError("", "Step already exists!");
        ////    }
        ////    return View(_stepService.GetById(stepDTO.Id));

        ////}

        ////public IActionResult Delete(int id)
        ////{
        ////    int projectId = (int)_stepService.GetById(id).ProjectId;
        ////    _stepService.Delete(id);
        ////    return RedirectToAction("Show", "Step", new { id = projectId });
        ////}

        // Download file by click

        public FileResult GetFile(int id)
        {
            var document = _documentService.GetById(id);
            byte[] fileContent = document.File;
            var currentFileType = document.Type;

            if (currentFileType != null)
                return File(fileContent, currentFileType);
            else
                return File(fileContent, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}
