using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Onion.AppCore.DTO;
using Onion.AppCore.Interfaces;
using Onion.AppCore;

namespace Onion.WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _customerService;
        private readonly IProject _projectService;
        private readonly IOperation _operationService;


        public CustomerController(ICustomer customerService, IProject projectService, IOperation operationService)
        {
            _customerService = customerService;
            _projectService = projectService;
            _operationService = operationService;
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
                _operationService.Create(Enums.OperationTypes.Create.ToString(),
                        Enums.ObjectNames.Customer.ToString(), fullCustomerDTO.CustomerDTO.Name, User.Identity.Name, fullCustomerDTO.CustomerDTO.ProjectId);
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
            var customerDTO = _customerService.GetList().First(x => x.Id == id);
            _customerService.Delete(id);
            _operationService.Create(Enums.OperationTypes.Delete.ToString(),
                Enums.ObjectNames.Customer.ToString(), customerDTO.Name, User.Identity.Name, customerDTO.ProjectId);
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
                    _operationService.Create(Enums.OperationTypes.Update.ToString(),
                        Enums.ObjectNames.Customer.ToString(), customerDTO.Name, User.Identity.Name, customerDTO.ProjectId);
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
