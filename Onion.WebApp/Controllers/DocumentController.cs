using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System.Linq;

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


        public IActionResult Delete(int id)
        {
            int projectId = (int)_documentService.GetById(id).ProjectId;
            _documentService.Delete(id);
            return RedirectToAction("Show", "Document", new { id = projectId });
        }


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
