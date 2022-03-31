using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartment _DepServ;
        public DepartmentController(IDepartment DepServ)
        {
            _DepServ = DepServ;
        }


        [HttpGet]
        public IActionResult Show()
        {
            return View(_DepServ.GetList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(_DepServ.GetListDepTypesDTO());
        }


        [HttpPost]
        public ActionResult Create(DepartmentDTO dep)
        {
            _DepServ.Create(dep);
            return Redirect("~/Department/Show");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_DepServ.GetByIdDTO(id));
        }


        [HttpPost]
        public IActionResult Edit(int id, DepartmentDTO dep)
        {
            //ViewBag.ProjCurId = id;
            _DepServ.Update(id, dep);
            return Redirect("~/Department/Show");
        }

        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            _DepServ.Delete(id);
            return Redirect("~/Department/Show");
        }
    }
}
