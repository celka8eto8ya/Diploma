using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.AppCore.Services
{
    public class TeamService : ITeam
    {

        IGenericRepository<Team> _Teams;
        IGenericRepository<Project> _Projects;
        public TeamService(IGenericRepository<Team> Teams, IGenericRepository<Project> Projects)
        {
            _Teams = Teams;
            _Projects = Projects;
        }

        public IEnumerable<Team> GetList()
        {
            return _Teams.GetList();
        }

        public TeamDTO GetListProjectsDTO()
        {
            TeamDTO team = new TeamDTO()
            {
                AllProjects = _Projects.GetList()
            };
            return team;
        }

        public void Create(TeamDTO team)
        {
            Team team0 = new Team()
            {
                Name = team.Name,
                HeadName = team.HeadName,
                CreateDate = DateTime.Now.Date,
                EmployeeAmount = 0,
                Technologies = team.Technologies,
                ProjectId = team.ProjectId,
            };

            _Teams.Create(team0);
        }

        public void Delete(int id)
        {
            _Teams.Delete(id);
        }

        //public ProjectDTO GetByIdDTO(int id)
        //{
        //    Project proj = _Projects.GetById(id);
        //    ProjectDTO project = new ProjectDTO()
        //    {
        //        Name = proj.Name,
        //        Deadline = proj.Deadline,
        //        StartDate = proj.StartDate,
        //        TechStack = proj.TechStack,
        //        Cost = proj.Cost,
        //        // File .doc
        //        Instruction = proj.Instruction,
        //        UseArea = proj.UseArea
        //    };

        //    return project;
        //}

        //public Project GetById(int id)
        //{
        //    return _Projects.GetById(id);
        //}

        //public void Update(int id, ProjectDTO proj)
        //{
        //    Project project = GetById(id);
        //    if (project != null)
        //    {
        //        project.Name = proj.Name;
        //        project.Deadline = proj.Deadline;
        //        project.StartDate = proj.StartDate;
        //        project.TechStack = proj.TechStack;
        //        project.Cost = proj.Cost;
        //        // File .doc
        //        project.Instruction = proj.Instruction;
        //        project.UseArea = proj.UseArea;
        //    }

        //    _Projects.Update(project);
        //}
    }
}
