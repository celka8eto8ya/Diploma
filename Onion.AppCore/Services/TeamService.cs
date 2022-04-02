﻿using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Onion.AppCore.Services
{
    public class TeamService : ITeam
    {
        private readonly IGenericRepository<Team> _teamRepository;
        private readonly IGenericRepository<Project> _projectRepository;
     
        public TeamService(IGenericRepository<Team> teamRepository, IGenericRepository<Project> projectRepository)
        {
            _teamRepository = teamRepository;
            _projectRepository = projectRepository;
        }

        public IEnumerable<Team> GetList()
        {
            return _teamRepository.GetList();
        }

        public TeamDTO GetListTeams()
        {
            TeamDTO teamDTO = new TeamDTO()
            {
                AllProjects = _projectRepository.GetList()
            };
            return teamDTO;
        }

        public void Create(TeamDTO teamDTO)
        {
            Team team = new Team()
            {
                Name = teamDTO.Name,
                HeadName = teamDTO.HeadName,
                CreateDate = DateTime.Now.Date,
                EmployeeAmount = 0,
                Technologies = teamDTO.Technologies,
                ProjectId = teamDTO.ProjectId
            };

            _teamRepository.Create(team);
        }

        public void Delete(int id)
        {
            _teamRepository.Delete(id);
        }

        public TeamDTO GetById(int id)
        {
            Team team = _teamRepository.GetById(id);
            TeamDTO teamDTO = new TeamDTO()
            {
                Name = team.Name,
                HeadName = team.HeadName,
                Technologies = team.Technologies
            };

            return teamDTO;
        }

        public void Update(int id, TeamDTO teamDTO)
        {
            Team team = _teamRepository.GetById(id);
            if (team != null)
            {
                team.Name = teamDTO.Name;
                team.HeadName = teamDTO.HeadName;
                team.Technologies = teamDTO.Technologies;
                _teamRepository.Update(team);
            }
        }

    }
}
