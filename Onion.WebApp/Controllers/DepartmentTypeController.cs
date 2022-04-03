using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;

namespace Onion.WebApp.Controllers
{
    public class DepartmentTypeController : Controller
    {
        private readonly IDepartmentType _departmentTypeService;
      
        public DepartmentTypeController(IDepartmentType departmentTypeService)
        {
            _departmentTypeService = departmentTypeService;
        }


        [HttpGet]
        public IActionResult Show()
        {
            return View(_departmentTypeService.GetList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(DepartmentTypeDTO departmentTypeDTO)
        {
            if (ModelState.IsValid)
            {
                _departmentTypeService.Create(departmentTypeDTO);
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
            return View(_departmentTypeService.GetById(id));
        }


        [HttpPost]
        public IActionResult Edit(DepartmentTypeDTO departmentTypeDTO)
        {
            //ViewBag.ProjCurId = id;
            _departmentTypeService.Update(departmentTypeDTO);
            return Redirect("~/DepartmentType/Show");
        }

        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            _departmentTypeService.Delete(id);
            return Redirect("~/DepartmentType/Show");
        }
    }
}
