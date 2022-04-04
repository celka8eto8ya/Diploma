using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;

namespace Onion.WebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment _departmentService;
        private readonly IDepartmentType _departmentTypeService;

        public DepartmentController(IDepartment departmentService, IDepartmentType departmentTypeService)
        {
            _departmentService = departmentService;
            _departmentTypeService = departmentTypeService;
        }


        [HttpGet]
        public IActionResult Show()
        {
            return View(_departmentService.GetList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DepartmentTypes = _departmentTypeService.GetList();
            return View();
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
        public IActionResult Edit(DepartmentDTO departmentDTO)
        {
            _departmentService.Update(departmentDTO);
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
