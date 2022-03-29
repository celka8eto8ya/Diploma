using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.Entities;
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
        
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(Project proj)
        {
            if (ModelState.IsValid)
            {
                _ProjServ.Create(proj);
                ModelState.AddModelError("", "Employee is successfully created!");
                //return RedirectToAction("Show");
                //return Redirect("~/Home/About");
                //return Redirect("http://microsoft.com")
            }
            else
                ModelState.AddModelError("", "Not correct data!");

            return View();
        }
       
    }
}
