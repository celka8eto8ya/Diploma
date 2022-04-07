using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System;

namespace Onion.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;
        private readonly IRole _roleService;
        private readonly IDepartment _departmentService;
        private readonly IPersonalFile _personalFileService;

        public EmployeeController(IEmployee employeeService, IRole roleService, IDepartment departmentService, IPersonalFile personalFileService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
            _departmentService = departmentService;
            _personalFileService = personalFileService;
        }


        [HttpGet]
        public IActionResult Show()
        {
            return View(_employeeService.GetList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = _roleService.GetList();
            ViewBag.Departments = _departmentService.GetList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(FullEmployeeDTO fullEmployeeDTO)
        {
            if (!_employeeService.UniqueEmail(fullEmployeeDTO))
            {
                _employeeService.Create(fullEmployeeDTO);
                return Redirect("~/Employee/Show");
            }
            else
            {
                ModelState.AddModelError("", "Email isn`t unique!");
                ViewBag.Roles = _roleService.GetList();
                ViewBag.Departments = _departmentService.GetList();
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            _employeeService.Delete(id);
            return Redirect("~/Employee/Show");
        }


        [HttpGet]
        public IActionResult Edit(int id)
            => View(_employeeService.GetById(id));



        [HttpPost]
        public IActionResult Edit(EmployeeDTO employeeDTO)
        {
            _employeeService.Update(employeeDTO);
            return Redirect("~/Employee/Show");
        }

        [HttpGet]
        public IActionResult ShowPersonalFile(int id)
            => View(_personalFileService.GetByEmployeeId(id));

        [HttpPost]
        public IActionResult ShowPersonalFile(PersonalFileDTO personalFileDTO)
        {
            _personalFileService.Update(personalFileDTO);
            return Redirect("~/Employee/Show");
        }

    }
}
