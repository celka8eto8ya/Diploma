using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Onion.AppCore.Services
{
    public class ProjectService : IProject
    {
        IGenericRepository<Project> _Projects;
        public ProjectService(IGenericRepository<Project> Projects)
        {
            _Projects = Projects;
        }

        public IEnumerable<Project> GetList()
        {
            return _Projects.GetList();
        }

        public void Create(Project proj)
        {
            Project project = new Project
            {
                Name = proj.Name,
                //Deadline = proj.Deadline,
                //StartDate = proj.StartDate,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                TechStack = proj.TechStack,
                EmployeeAmount = 0,
                //Cost = proj.Cost,
                // File .doc
                Instruction = proj.Instruction,
                //UseArea = proj.UseArea
            };

            _Projects.Create(proj);
        }

        public void Delete(int id)
        {
            _Projects.Delete(id);
        }

        public Project GetById(int id)
        {
            return _Projects.GetById(id);
        }

        public void Update(Project proj)
        {
            _Projects.Update(proj);
        }
    }
}
