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



      


        // GET: TeamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TeamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
