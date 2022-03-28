using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.WebApp.Controllers
{
    public class ProjectController : Controller
    {
        IGenericRepository<Project> _ProjServ;
        public ProjectController(IGenericRepository<Project> ProjServ)
        {
            _ProjServ = ProjServ;
        }

        public IActionResult Show()
        {
            return View(_ProjServ.GetList());
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
