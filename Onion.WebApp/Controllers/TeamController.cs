using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;

namespace Onion.WebApp.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeam _teamService;
        public TeamController(ITeam teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        public ActionResult Show()
        {
            return View(_teamService.GetList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(_teamService.GetListTeams());
        }
        
        [HttpPost]
        public ActionResult Create(TeamDTO teamDTO)
        {
            _teamService.Create(teamDTO);
            return Redirect("~/Team/Show");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_teamService.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(int id, TeamDTO teamDTO)
        {
            //ViewBag.ProjCurId = id;
            _teamService.Update(id, teamDTO);
            return Redirect("~/Team/Show");
        }

        public IActionResult Delete(int id)
        {
            _teamService.Delete(id);
            return Redirect("~/Team/Show");
        }
        
    }
}
