using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System.Linq;

namespace Onion.WebApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeam _teamService;
        private readonly IProject _projectService;
        public TeamController(ITeam teamService, IProject projectService)
        {
            _teamService = teamService;
            _projectService = projectService;
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
                    _teamService.Create(teamDTO);
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
            _teamService.Delete(id);
            return Redirect("~/Team/Show");
        }

    }
}
