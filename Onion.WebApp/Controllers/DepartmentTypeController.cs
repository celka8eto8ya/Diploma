using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.WebApp.Controllers
{
    public class DepartmentTypeController : Controller
    {

        IDepartmentType _DepTypeServ;
        public DepartmentTypeController(IDepartmentType DepTypeServ)
        {
            _DepTypeServ = DepTypeServ;
        }


        [HttpGet]
        public IActionResult Show()
        {
            return View(_DepTypeServ.GetList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(DepartmentTypeDTO depType)
        {
            if (ModelState.IsValid)
            {
                _DepTypeServ.Create(depType);
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
            return View(_DepTypeServ.GetByIdDTO(id));
        }


        [HttpPost]
        public IActionResult Edit(int id, DepartmentTypeDTO dep)
        {
            //ViewBag.ProjCurId = id;
            _DepTypeServ.Update(id, dep);
            return Redirect("~/DepartmentType/Show");
        }

        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            _DepTypeServ.Delete(id);
            return Redirect("~/DepartmentType/Show");
        }
    }
}
