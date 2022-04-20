using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Onion.WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;
        private readonly IRole _roleService;
        private readonly IDepartment _departmentService;
        private readonly IPersonalFile _personalFileService;
        private readonly ITeam _teamService;

        public EmployeeController(IEmployee employeeService,
            IRole roleService,
            IDepartment departmentService,
            IPersonalFile personalFileService,
            ITeam teamService
            )
        {
            _employeeService = employeeService;
            _roleService = roleService;
            _departmentService = departmentService;
            _personalFileService = personalFileService;
            _teamService = teamService;
        }


        [HttpGet]
        public IActionResult Show()
        {
            ViewBag.Departments = _departmentService.GetList();
            ViewBag.Roles = _roleService.GetList();
            ViewBag.Teams = _teamService.GetList();

            return View(_employeeService.GetList());
        }

        [HttpPost]
        public IActionResult Show(int departmentId, int roleId, int teamId)
        {
            ViewBag.Departments = _departmentService.GetList();
            ViewBag.Roles = _roleService.GetList();
            ViewBag.Teams = _teamService.GetList();

            var employees = _employeeService.GetList();
            if (departmentId > 0)
                employees = employees.Where(x => x.DepartmentId == departmentId);

            if (roleId > 0)
                employees = employees.Where(x => x.RoleId == roleId);
          
            if (teamId > 0)
                employees = employees.Where(x => x.TeamId == teamId);

            ViewBag.departmentId = departmentId;
            ViewBag.roleId = roleId;
            ViewBag.teamId = teamId;

            return View(employees);
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
            if (!_employeeService.IsUniqueFullEmployee(fullEmployeeDTO))
            {
                _employeeService.Create(fullEmployeeDTO);
                return Redirect("~/Employee/Show");
            }
            else
            {
                ModelState.AddModelError("", "Employee already exists!");
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
        {
            if (_employeeService.GetList().Any(x => x.Id == id) && id > 0)
                return View(_employeeService.GetById(id));
            else
            {
                ModelState.AddModelError("", "Eror 400 - Bad Request!");
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(EmployeeDTO employeeDTO)
        {
            if (_employeeService.GetList().Any(x => x.Id == employeeDTO.Id) && employeeDTO.Id > 0)
            {
                if (!_employeeService.IsUniqueEmployee(employeeDTO))
                {
                    _employeeService.Update(employeeDTO);
                    return Redirect("~/Employee/Show");
                }
                else
                {
                    ModelState.AddModelError("", "Employee already exists!");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Eror 400 - Bad Request!");
                return View();
            }
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



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AuthenticationDTO authenticationDTO)
        {
            if (ModelState.IsValid)
            {
                if (_employeeService.IsLogin(authenticationDTO))
                {
                    await Authenticate(authenticationDTO.Email); // аутентификация

                    if (_employeeService.CheckRole(authenticationDTO.Email) == "Admin")
                        return RedirectToAction("Show", "Employee");
                    else
                        return RedirectToAction("Show", "Project");
                }
                ModelState.AddModelError("", "This User doesn't exist !");
            }
            else
                ModelState.AddModelError("", "Problem with entered data !");

            return View();
        }



        private async Task Authenticate(string userName)
        {
            //var user = UserServ.UserList().SingleOrDefault(user => user.Email == userName);
            //if (user.Available == true)
            //{
            //string role = user.Privileges == true ? "Admin" : "User";
            // создаем один claim
            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
                    new Claim(ClaimTypes.Role,_employeeService.CheckRole(userName))//установка роли
                };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            //}
            //else { LogOut(); }
        }

        public ActionResult LogOut()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Employee");
        }
    }
}
