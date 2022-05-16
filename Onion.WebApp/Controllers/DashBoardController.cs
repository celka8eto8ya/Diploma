using Microsoft.AspNetCore.Mvc;
using Onion.AppCore;
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
        private readonly IPersonalFile _personalFileService;
        private readonly ITask _taskService;
        private readonly IOperation _operationService;


        public DashBoardController(IDashBoard dashBoardService, IDepartment departmentService, IEmployee employeeService,
            IProject projectService, ITeam teamService, IPersonalFile personalFileService, ITask taskService,
            IOperation operationService)
        {
            _dashBoardService = dashBoardService;
            _departmentService = departmentService;
            _employeeService = employeeService;
            _projectService = projectService;
            _teamService = teamService;
            _personalFileService = personalFileService;
            _taskService = taskService;
            _operationService = operationService;
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
                _operationService.Create(Enums.OperationTypes.Create.ToString(), Enums.ObjectNames.DashBoard.ToString(),
                    ViewBag.proName, User.Identity.Name, projectId);

                var personalFileDTO = _personalFileService.GetByEmployeeId(id);
                personalFileDTO.SetProjectDate = System.DateTime.Now;
                _taskService.GetList().Where(x => x.TaskDTO.EmployeeId == personalFileDTO.EmployeeId).ToList().
                    ForEach(y => personalFileDTO.AVGTaskCost += y.TaskDTO.Cost);
                _personalFileService.Update(personalFileDTO);
                ViewBag.CreateResult = "Set in project is successfully created!";
            }

            return View();
        }

        public IActionResult DeleteSetting(int id)
        {
            var personalFileDTO = _personalFileService.GetByEmployeeId(id);
            _taskService.GetList().Where(x => x.TaskDTO.EmployeeId == personalFileDTO.EmployeeId).ToList().
                ForEach(y => personalFileDTO.AVGTaskCost += y.TaskDTO.Cost);
            _personalFileService.Update(personalFileDTO);
            var employee = _employeeService.GetById(id);
            int projectId = _projectService.GetById(_teamService.GetById((int)employee.TeamId).ProjectId).Id;

            _dashBoardService.Delete(id);
            _operationService.Create(Enums.OperationTypes.Delete.ToString(), Enums.ObjectNames.DashBoard.ToString(),
                    employee.FullName, User.Identity.Name, projectId);
            return Redirect("~/Employee/Show");
        }

    }
}
