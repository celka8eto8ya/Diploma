using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Onion.AppCore.Interfaces;
using System.Linq;
using System.Text;

namespace Onion.WebApp.Controllers
{
    public class OperationController : Controller
    {
        private readonly IProject _projectService;
        private readonly IOperation _operationService;

        public OperationController(IProject projectService, IOperation operationService)
        {
            _projectService = projectService;
            _operationService = operationService;
        }


        [HttpGet]
        public IActionResult Show(int id)
        {
            ViewBag.Project = _projectService.GetById(id);
            return View(_operationService.GetList().Where(x => x.ProjectId == id));
        }


        public IActionResult ExportData(int projectId, string format)
        {
            var project = _projectService.GetById(projectId);
            var operationDTO = _operationService.GetList().Where(x => x.ProjectId == projectId);
            switch (format)
            {
                case "Word":
                    Response.Clear();
                    Response.Headers.Add("Content-Type", "application/msword");
                    Response.Headers.Add("Content-disposition", $"attachment; filename=OperationsBy{project.Name}.doc");
                    Response.Body.WriteAsync(_operationService.ExportToWord(operationDTO));
                    Response.Body.FlushAsync();
                    break;
                case "Json":
                    string jsonProductList = new JavaScriptSerializer().Serialize(operationDTO);
                    byte[] byteArray = ASCIIEncoding.ASCII.GetBytes(jsonProductList);

                    Response.Clear();
                    Response.Headers.Clear();
                    Response.ContentType = "application/json";
                    Response.Headers.Add("Content-Length", jsonProductList.Length.ToString());
                    Response.Headers.Add("Content-Disposition", $"attachment; filename=Operations{project.Name}.json;");
                    Response.Body.WriteAsync(byteArray);
                    Response.Body.FlushAsync();
                    break;
                case "Xml":
                    Response.Clear();
                    Response.Headers.Clear();
                    Response.ContentType = "application/xml";
                    Response.Headers.Add("Content-Disposition", $"attachment; filename=Operations{project.Name}.xml;");
                    Response.Body.WriteAsync(_operationService.ExportToXML(operationDTO));
                    Response.Body.Flush();
                    break;
            }
            return null;
        }

    }
}
