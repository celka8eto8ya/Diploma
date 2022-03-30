using Onion.AppCore.DTO;
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

        public void Create(ProjectDTO proj)
        {
            Project project = new Project
            {
                Name = proj.Name,
                Deadline = proj.Deadline,
                StartDate = proj.StartDate,
                CreateDate = DateTime.Now.Date,
                UpdateDate = DateTime.Now.Date,
                TechStack = proj.TechStack,
                EmployeeAmount = 0,
                Cost = proj.Cost,
                // File .doc
                Instruction = proj.Instruction,
                UseArea = proj.UseArea
            };

            _Projects.Create(project);
        }

        public void Delete(int id)
        {
            _Projects.Delete(id);
        }

        public ProjectDTO GetByIdDTO(int id)
        {
            Project proj = _Projects.GetById(id);
            ProjectDTO project = new ProjectDTO()
            {
                Name = proj.Name,
                Deadline = proj.Deadline,
                StartDate = proj.StartDate,
                TechStack = proj.TechStack,
                Cost = proj.Cost,
                // File .doc
                Instruction = proj.Instruction,
                UseArea = proj.UseArea
            };

            return project;
        }

        public Project GetById(int id)
        {
            return _Projects.GetById(id);
        }

        public void Update(int id, ProjectDTO proj)
        {
            Project project = GetById(id);
            if (project != null)
            {
                project.Name = proj.Name;
                project.Deadline = proj.Deadline;
                project.StartDate = proj.StartDate;
                project.TechStack = proj.TechStack;
                project.Cost = proj.Cost;
                // File .doc
                project.Instruction = proj.Instruction;
                project.UseArea = proj.UseArea;
            }

            _Projects.Update(project);
        }
    }
}
