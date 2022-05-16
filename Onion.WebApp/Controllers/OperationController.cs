using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.Interfaces;
using System.Linq;

namespace Onion.WebApp.Controllers
{
    public class OperationController : Controller
    {
        private readonly IProject _projectService;
        private readonly IOperation _operationService;

        public OperationController(IProject projectService, IOperation operationService)
        {
            _projectService = projectService;
            _operationService = operationService;
        }


        [HttpGet]
        public IActionResult Show(int id)
        {
            ViewBag.Project = _projectService.GetById(id);
            return View(_operationService.GetList().Where(x => x.ProjectId == id));
        }

    }
}
