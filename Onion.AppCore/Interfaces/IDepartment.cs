using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
     public interface IDepartment
    {
        IEnumerable<Department> GetList(); 
        DepartmentDTO GetById(int id); 
        void Create(DepartmentDTO departmnetDTO); 
        void Update(DepartmentDTO departmnetDTO); 
        void Delete(int id); 
    }
}
