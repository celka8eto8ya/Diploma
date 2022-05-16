using Microsoft.AspNetCore.Mvc;
using Onion.AppCore;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System.Linq;

namespace Onion.WebApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeam _teamService;
        private readonly IProject _projectService;
        private readonly IOperation _operationService;

        public TeamController(ITeam teamService, IProject projectService, IOperation operationService)
        {
            _teamService = teamService;
            _projectService = projectService;
            _operationService = operationService;
        }


        [HttpGet]
        public ActionResult Show(int id)
        {
            ViewBag.Project = _projectService.GetById(id);
            return View(_teamService.GetList().Where(x => x.ProjectId == id));
        }


        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == id);
            ViewBag.ProjectList = _projectService.GetList();
            return View();
        }


        [HttpPost]
        public ActionResult Create(TeamDTO teamDTO)
        {
            ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == teamDTO.ProjectId);

            if (!_teamService.IsUnique(teamDTO))
            {
                if (ModelState.IsValid)
                {
                    var team = _teamService.Create(teamDTO);
                    _operationService.Create(Enums.OperationTypes.Create.ToString(), Enums.ObjectNames.Team.ToString(),
                        team.Name, User.Identity.Name, team.ProjectId);
                    ViewBag.CreateResult = "Team is successfully created!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Team already exists!");
            }

            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == _teamService.GetById(id).ProjectId);
            return View(_teamService.GetById(id));
        }


        [HttpPost]
        public IActionResult Edit(TeamDTO teamDTO)
        {
            ViewBag.Project = _projectService.GetList().First(x => x.ProjectDTO.Id == teamDTO.ProjectId);
            if (!_teamService.IsUnique(teamDTO))
            {
                if (ModelState.IsValid)
                {
                    _teamService.Update(teamDTO);
                    _operationService.Create(Enums.OperationTypes.Update.ToString(), Enums.ObjectNames.Team.ToString(),
                       teamDTO.Name, User.Identity.Name, teamDTO.ProjectId);
                    ViewBag.CreateResult = "Team is successfully edited!";
                }
                else
                {
                    ModelState.AddModelError("", "Not correct data!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Team already exists!");
            }

            return View(teamDTO);
        }

        public IActionResult Delete(int id)
        {
            var team = _teamService.GetById(id);
            _teamService.Delete(id);
            _operationService.Create(Enums.OperationTypes.Delete.ToString(), Enums.ObjectNames.Team.ToString(),
                      team.Name, User.Identity.Name, team.ProjectId);
            return RedirectToAction("Show", "Team", new { id = team.ProjectId });
        }

    }
}
