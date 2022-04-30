using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;

namespace Onion.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _customerService;
        private readonly IProject _projectService;

        public CustomerController(ICustomer customerService, IProject projectService)
        {
            _customerService = customerService;
            _projectService = projectService;
        }


        [HttpGet]
        public IActionResult Show()
        {
            ViewBag.Projects = _projectService.GetList();
            return View(_customerService.GetList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Projects = _projectService.GetList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(FullCustomerDTO fullCustomerDTO)
        {
            if (!_customerService.IsUniqueFullCustomer(fullCustomerDTO))
            {
                _customerService.Create(fullCustomerDTO);
                return Redirect("~/Customer/Show");
            }
            else
            {
                ModelState.AddModelError("", "Customer already exists!");
                ViewBag.Projects = _projectService.GetList();
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            _customerService.Delete(id);
            return Redirect("~/Customer/Show");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (_customerService.GetList().Any(x => x.Id == id) && id > 0)
                return View(_customerService.GetById(id));
            else
            {
                ModelState.AddModelError("", "Eror 400 - Bad Request!");
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(CustomerDTO customerDTO)
        {
            if (_customerService.GetList().Any(x => x.Id == customerDTO.Id) && customerDTO.Id > 0)
            {
                if (!_customerService.IsUniqueCustomer(customerDTO))
                {
                    _customerService.Update(customerDTO);
                    return Redirect("~/Customer/Show");
                }
                else
                {
                    ModelState.AddModelError("", "Customer already exists!");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Eror 400 - Bad Request!");
                return View();
            }
        }

    }
}
