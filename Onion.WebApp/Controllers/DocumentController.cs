using Microsoft.AspNetCore.Mvc;
using Onion.AppCore;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System.Linq;

namespace Onion.WebApp.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocument _documentService;
        private readonly IProject _projectService;
        private readonly IOperation _operationService;

        public DocumentController(IDocument documentService, IProject projectService, IOperation operationService)
        {
            _documentService = documentService;
            _projectService = projectService;
            _operationService = operationService;
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
                    var document = _documentService.Create(documentDTO);
                    _operationService.Create(Enums.OperationTypes.Create.ToString(), Enums.ObjectNames.Document.ToString(),
                        document.Name, User.Identity.Name, document.ProjectId);
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
            var document = _documentService.GetById(id);
            _documentService.Delete(id);
            _operationService.Create(Enums.OperationTypes.Delete.ToString(), Enums.ObjectNames.Document.ToString(),
                document.Name, User.Identity.Name, document.ProjectId);
            return RedirectToAction("Show", "Document", new { id = document.ProjectId });
        }


        public FileResult GetFile(int id)
        {
            var document = _documentService.GetById(id);
            byte[] fileContent = document.File;
            var currentFileType = document.Type;

            _operationService.Create(Enums.OperationTypes.Open.ToString(), Enums.ObjectNames.Document.ToString(),
               document.Name, User.Identity.Name, document.ProjectId);

            if (currentFileType != null)
                return File(fileContent, currentFileType);
            else
                return File(fileContent, System.Net.Mime.MediaTypeNames.Application.Octet);
        }
    }
}
