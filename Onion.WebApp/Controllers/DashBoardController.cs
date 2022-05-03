using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System.Linq;

namespace Onion.WebApp.Controllers
{
    public class DashBoardController : Controller
    {
        private readonly IDashBoard _dashBoardService;
        private readonly IDepartment _departmentService;
        private readonly IEmployee _employeeService;
        private readonly IProject _projectService;
        private readonly ITeam _teamService;


        public DashBoardController(IDashBoard dashBoardService, IDepartment departmentService, IEmployee employeeService,
            IProject projectService, ITeam teamService)
        {
            _dashBoardService = dashBoardService;
            _departmentService = departmentService;
            _employeeService = employeeService;
            _projectService = projectService;
            _teamService = teamService;
        }

        [HttpGet]
        public IActionResult Show()
        {
            var dashBoards = _dashBoardService.GetFullList();
            if (User.IsInRole("Employee"))
            {
                dashBoards = dashBoards.Where(x => x.Employee == _employeeService.GetById(_employeeService.GetByEmailEntity(User.Identity.Name)).FullName);
            }
            return View(dashBoards);
        }


        [HttpGet]
        public IActionResult ShowResources()
        {
            var dashBoards = _dashBoardService.GetFullList();
            if (User.IsInRole("Employee"))
            {
                dashBoards = dashBoards.Where(x => x.Employee == _employeeService.GetById(
                    _employeeService.GetByEmailEntity(User.Identity.Name)).FullName);
            }

            return new JsonResult(dashBoards.Select(x => new { id = x.Id, title = x.Employee }));
        }

        [HttpGet]
        public IActionResult ShowEvents()
        {
            var dashBoards = _dashBoardService.GetFullList();
            if (User.IsInRole("Employee"))
            {
                dashBoards = dashBoards.Where(x => x.Employee == _employeeService.GetById(
                    _employeeService.GetByEmailEntity(User.Identity.Name)).FullName);
            }

            return new JsonResult(dashBoards.Select(x => new
            {
                id = x.Id,
                resourceId = x.Id,
                start = x.StartDate.ToString("yyyy-MM-dd"),
                end = x.EndDate.ToString("yyyy-MM-dd"),
                title = x.Project
            }));
        }


        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.Employee = _employeeService.GetById(id);

            ViewBag.Projects = _projectService.GetList();
            ViewBag.Teams = _teamService.GetList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(DashBoardDTO dashBoardDTO, int teamId, int projectId, int id, string filter, string set)
        {
            ViewBag.Teams = _teamService.GetList().Where(x => x.ProjectId == projectId);
            ViewBag.Projects = _projectService.GetList();
            ViewBag.proId = projectId;

            // after redirect remove
            ViewBag.Employee = _employeeService.GetById(id);

            ViewBag.teamId = teamId;
            ViewBag.proName = _projectService.GetById(projectId).Name;
            ViewBag.empId = id;

            ViewBag.filter = filter;
            ViewBag.set = set;
            dashBoardDTO.EmployeeId = id;
            ViewBag.empDTO = dashBoardDTO.EmployeeId;


            if (set != null)
            {
                _dashBoardService.Create(dashBoardDTO, teamId);
                ViewBag.CreateResult = "Set in project is successfully created!";
            }

            //return Redirect("~/Employee/Show");

            return View();
            //if (!_employeeService.IsUniqueFullEmployee(fullEmployeeDTO))
            //{
            //    _employeeService.Create(fullEmployeeDTO);
            //    return Redirect("~/Employee/Show");
            //}
            //else
            //{
            //    ModelState.AddModelError("", "Employee already exists!");
            //    ViewBag.Roles = _roleService.GetList();
            //    ViewBag.Departments = _departmentService.GetList();
            //    return View();
            //}
        }

        public IActionResult DeleteSetting(int id)
        {
            _dashBoardService.Delete(id);
            return Redirect("~/Employee/Show");
        }

    }
}
