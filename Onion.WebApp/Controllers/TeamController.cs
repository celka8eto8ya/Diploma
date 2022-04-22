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
            => View(_teamService.GetList().Where(x => x.ProjectId == id));

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ProjectList = _projectService.GetList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(TeamDTO teamDTO)
        {
            _teamService.Create(teamDTO);
            return Redirect("~/Project/Show");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_teamService.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(TeamDTO teamDTO)
        {
            _teamService.Update(teamDTO);
            return Redirect("~/Team/Show");
        }

        public IActionResult Delete(int id)
        {
            _teamService.Delete(id);
            return Redirect("~/Team/Show");
        }

    }
}
