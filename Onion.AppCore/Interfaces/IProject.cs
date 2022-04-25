using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IProject
    {
        IEnumerable<FullProjectDTO> GetList(); 
        ProjectDTO GetById(int id); 
        void Create(ProjectDTO projectDTO); 
        void Update(ProjectDTO projectDTO); 
        void Delete(int id);
        bool IsUniqueProject(ProjectDTO projectDTO);
    }
}
