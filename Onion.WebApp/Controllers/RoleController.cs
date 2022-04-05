using Microsoft.AspNetCore.Mvc;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Onion.WebApp.Controllers
{
    public class RoleController : Controller
    {
        [HttpGet]
        public IActionResult Show()
        {
            return View();
        }
    }
}
