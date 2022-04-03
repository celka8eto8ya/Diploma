using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;

namespace Onion.WebApp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProject _projectService;

        public ProjectController(IProject projectService)
        {
            _projectService = projectService;
        }


        [HttpGet]
        public IActionResult Show()
        {
            return View(_projectService.GetList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


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
            return View(_projectService.GetById(id));
        }


        [HttpPost]
        public IActionResult Edit(int id, ProjectDTO projectDTO)
        {
            //ViewBag.ProjCurId = id;
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
