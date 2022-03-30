using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;

namespace Onion.WebApp.Controllers
{
    public class ProjectController : Controller
    {
        IProject _ProjServ;
        public ProjectController(IProject ProjServ)
        {
            _ProjServ = ProjServ;
        }


        [HttpGet]
        public IActionResult Show()
        {
            return View(_ProjServ.GetList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(ProjectDTO proj)
        {
            if (ModelState.IsValid)
            {
                _ProjServ.Create(proj);
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
            return View(_ProjServ.GetByIdDTO(id));
        }


        [HttpPost]
        public IActionResult Edit(int id, ProjectDTO proj)
        {
            //ViewBag.ProjCurId = id;
            _ProjServ.Update(id, proj);
            return Redirect("~/Project/Show");
        }

        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            _ProjServ.Delete(id);
            return Redirect("~/Project/Show");
        }

    }
}
