﻿using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Onion.AppCore.Services
{
    public class ProjectService : IProject
    {
        private readonly IGenericRepository<Project> _projectRepository;
        
        public ProjectService(IGenericRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IEnumerable<Project> GetList()
        {
            return _projectRepository.GetList();
        }

        public void Create(ProjectDTO projectDTO)
        {
            Project project = new Project
            {
                Name = projectDTO.Name,
                Deadline = projectDTO.Deadline,
                StartDate = projectDTO.StartDate,
                CreateDate = DateTime.Now.Date,
                UpdateDate = DateTime.Now.Date,
                TechStack = projectDTO.TechStack,
                EmployeeAmount = 0,
                Cost = projectDTO.Cost,
                // File .doc
                Instruction = projectDTO.Instruction,
                UseArea = projectDTO.UseArea
            };

            _projectRepository.Create(project);
        }

        public void Delete(int id)
        {
            _projectRepository.Delete(id);
        }

        public ProjectDTO GetById(int id)
        {
            Project project = _projectRepository.GetById(id);
            ProjectDTO projectDTO = new ProjectDTO()
            {
                Name = project.Name,
                Deadline = project.Deadline,
                StartDate = project.StartDate,
                TechStack = project.TechStack,
                Cost = project.Cost,
                // File .doc
                Instruction = project.Instruction,
                UseArea = project.UseArea
            };

            return projectDTO;
        }

     

        public void Update(int id, ProjectDTO projectDTO)
        {
            Project project = _projectRepository.GetById(id);
            if (project != null)
            {
                project.Name = projectDTO.Name;
                project.Deadline = projectDTO.Deadline;
                project.StartDate = projectDTO.StartDate;
                project.TechStack = projectDTO.TechStack;
                project.Cost = projectDTO.Cost;
                // File .doc
                project.Instruction = projectDTO.Instruction;
                project.UseArea = projectDTO.UseArea;

                _projectRepository.Update(project);
            }
        }

    }
}
