using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;

namespace Onion.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;
        private readonly IRole _roleService;
        private readonly IDepartment _departmentService;

        public EmployeeController(IEmployee employeeService, IRole roleService, IDepartment departmentService)
        {
            _employeeService = employeeService;
            _roleService = roleService;
            _departmentService = departmentService;
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


    }
}
