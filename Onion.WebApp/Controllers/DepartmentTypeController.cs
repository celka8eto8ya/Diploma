using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;

namespace Onion.WebApp.Controllers
{
    public class DepartmentTypeController : Controller
    {
        private readonly IDepartmentType _departmentTypeService;

        public DepartmentTypeController(IDepartmentType departmentTypeService)
            => _departmentTypeService = departmentTypeService;


        [HttpGet]
        public IActionResult Show()
            => View(_departmentTypeService.GetList());


        [HttpGet]
        public IActionResult Create()
            => View();


        [HttpPost]
        public IActionResult Create(DepartmentTypeDTO departmentTypeDTO)
        {
            if (!_departmentTypeService.IsUnique(departmentTypeDTO))
            {
                if (ModelState.IsValid)
                {
                    _departmentTypeService.Create(departmentTypeDTO);
                    ViewBag.CreateResult = "Department Type is successfully created!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Department Type already exists!");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
            => View(_departmentTypeService.GetById(id));


        [HttpPost]
        public IActionResult Edit(DepartmentTypeDTO departmentTypeDTO)
        {
            if (!_departmentTypeService.IsUnique(departmentTypeDTO))
            {
                if (ModelState.IsValid)
                {
                    _departmentTypeService.Update(departmentTypeDTO);
                    ViewBag.CreateResult = "Department Type is successfully edited!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Department Type already exists!");
            }

            return View(departmentTypeDTO);
        }

        public IActionResult Delete(int id)
        {
            _departmentTypeService.Delete(id);
            return Redirect("~/DepartmentType/Show");
        }
    }
}
