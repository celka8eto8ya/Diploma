using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IProject
    {
        IEnumerable<Project> GetList(); 
        ProjectDTO GetById(int id); 
        void Create(ProjectDTO projectDTO); 
        void Update(ProjectDTO projectDTO); 
        void Delete(int id); 
    }
}
