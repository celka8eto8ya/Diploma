using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;

namespace Onion.WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _departmentService;
       
        public DepartmentController(IDepartment departmentService)
        {
            _departmentService = departmentService;
        }


        [HttpGet]
        public IActionResult Show()
        {
            return View(_departmentService.GetList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View(_departmentService.GetListDepartmentTypes());
        }


        [HttpPost]
        public ActionResult Create(DepartmentDTO departmentDTO)
        {
            _departmentService.Create(departmentDTO);
            return Redirect("~/Department/Show");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_departmentService.GetById(id));
        }


        [HttpPost]
        public IActionResult Edit(int id, DepartmentDTO departmentDTO)
        {
            //ViewBag.ProjCurId = id;
            _departmentService.Update(id, departmentDTO);
            return Redirect("~/Department/Show");
        }

        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            _departmentService.Delete(id);
            return Redirect("~/Department/Show");
        }

    }
}
