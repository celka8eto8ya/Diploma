using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using Onion.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.WebApp.Controllers
{
    public class NewEmployeeController : Controller
    {
        IGenericRepository<Employee> _Employees;
        IGenericRepository<Department> _Departments;
        public NewEmployeeController(IGenericRepository<Employee> Employees, IGenericRepository<Department> Departments)
        {
            _Employees = Employees;
            _Departments = Departments;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewEmployeeModel model)
        {

            if (ModelState.IsValid)
            {
                _Departments.Create(new Department() { Name="First"});

                Employee emp = new Employee
                {
                    Name = model.Name,
                    CreateDate = DateTime.Now,
                    // Name of tech stack (frontend developer)
                    TechStack = model.TechStack,
                    // Years Amount 
                    Expirence = model.Expirence,
                    Position = model.Position,
                    // List hard skills
                    Technologies = model.Technologies,
                    // Jun, Middle, Senior
                    Level = model.Level,

                    DepartmentId = 1
                };
                _Employees.Create(emp);
                ModelState.AddModelError("", "Employee is successfully created!");
                //return RedirectToAction("Show");
            }
            else
                ModelState.AddModelError("", "Not correct data!");

            return View();
        }

    }
}
