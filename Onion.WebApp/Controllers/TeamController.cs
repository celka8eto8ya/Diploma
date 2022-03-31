using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using System;
using System.Threading.Tasks;

namespace Onion.WebApp.Controllers
{
    public class TeamController : Controller
    {
        ITeam _TeamServ;
        IProject _ProjectServ;
        public TeamController(ITeam TeamServ, IProject ProjectServ)
        {
            _TeamServ = TeamServ;
             _ProjectServ = ProjectServ;
        }

        // GET: TeamController
        public ActionResult Show()
        {
            return View(_TeamServ.GetList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(_TeamServ.GetListProjectsDTO());
        }
        
        [HttpPost]
        public ActionResult Create(TeamDTO team)
        {
            _TeamServ.Create(team);
            return Redirect("~/Team/Show");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(_TeamServ.GetByIdDTO(id));
        }


        [HttpPost]
        public IActionResult Edit(int id, TeamDTO proj)
        {
            //ViewBag.ProjCurId = id;
            _TeamServ.Update(id, proj);
            return Redirect("~/Team/Show");
        }

        //[HttpDelete]
        public IActionResult Delete(int id)
        {
            _TeamServ.Delete(id);
            return Redirect("~/Team/Show");
        }

        
    }
}
