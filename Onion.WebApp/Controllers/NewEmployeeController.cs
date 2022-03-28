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
        public NewEmployeeController(IGenericRepository<Employee> Employees)
        {
            _Employees = Employees;
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

                Employee emp = new Employee
                {
                    FullName = model.FullName,
                    CreateDate = DateTime.Now,
                    // Name of tech stack (frontend developer)
                    TechStackName = model.TechStackName,
                    // Years Amount 
                    Experience = model.Experience,
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
