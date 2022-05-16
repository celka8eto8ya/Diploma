using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IProject
    {
        IEnumerable<FullProjectDTO> GetList(); 
        ProjectDTO GetById(int id); 
        Project Create(ProjectDTO projectDTO); 
        void Update(ProjectDTO projectDTO); 
        void Delete(int id);
        bool IsUniqueProject(ProjectDTO projectDTO);
    }
}
