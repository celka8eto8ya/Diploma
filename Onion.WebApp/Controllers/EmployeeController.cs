using Microsoft.AspNetCore.Mvc;

namespace Onion.WebApp.Controllers
{
    public class EmployeeController : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

    }
}
