using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IDepartmentType
    {
        IEnumerable<DepartmentType> GetList(); 
        DepartmentTypeDTO GetById(int id); 
        void Create(DepartmentTypeDTO departmnetTypeDTO); 
        void Update(DepartmentTypeDTO departmnetTypeDTO); 
        void Delete(int id); 
    }
}
