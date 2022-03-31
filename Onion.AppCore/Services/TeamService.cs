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

        public TeamDTO GetByIdDTO(int id)
        {
            Team team0 = _Teams.GetById(id);
            TeamDTO team = new TeamDTO()
            {
                Name = team0.Name,
                HeadName = team0.HeadName,
                Technologies = team0.Technologies
            };

            return team;
        }



        //public Project GetById(int id)
        //{
        //    return _Projects.GetById(id);
        //}

        public void Update(int id, TeamDTO team0)
        {
            Team team = _Teams.GetById(id);
            if (team != null)
            {
                team.Name = team0.Name;
                team.HeadName = team0.HeadName;
                team.Technologies = team0.Technologies;
                _Teams.Update(team);
            }


        }
    }
}
