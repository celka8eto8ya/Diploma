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
            => View(_departmentService.GetList());


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.DepartmentTypes = _departmentTypeService.GetList();
            return View();
        }


        [HttpPost]
        public ActionResult Create(DepartmentDTO departmentDTO)
        {
            ViewBag.DepartmentTypes = _departmentTypeService.GetList();
            if (!_departmentService.IsUnique(departmentDTO))
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Create(departmentDTO);
                    ViewBag.CreateResult = "Department is successfully created!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Department already exists!");
            }
            return View(departmentDTO);
        }


        [HttpGet]
        public IActionResult Edit(int id)
            => View(_departmentService.GetById(id));


        [HttpPost]
        public IActionResult Edit(DepartmentDTO departmentDTO)
        {
            if (!_departmentService.IsUnique(departmentDTO))
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Update(departmentDTO);
                    ViewBag.CreateResult = "Department is successfully edited!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Department already exists!");
            }

            return View(departmentDTO);
        }

        public IActionResult Delete(int id)
        {
            _departmentService.Delete(id);
            return Redirect("~/Department/Show");
        }

    }
}
