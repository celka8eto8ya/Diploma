using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetList();
        //DepartmentDTO GetById(int id);
        void Create(EmployeeDTO employeeDTO);
        //void Update(DepartmentDTO departmnetDTO);
        //void Delete(int id);



        //List<Document> AllDocs();
        //List<Document> LastFiveDocs(string login);
        //List<Document> DoSort(List<Document> Docs, string sortOrder, string searchString, string begDate, string endDate);

        //public void DeleteDoc(int id);
        //List<Document> ShowVersions(int id);
    }
}
