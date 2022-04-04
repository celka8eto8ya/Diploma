using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Onion.AppCore.Services
{
    public class TeamService : ITeam
    {
        private readonly IGenericRepository<Team> _teamRepository;

        public TeamService(IGenericRepository<Team> teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public IEnumerable<Team> GetList()
        {
            return _teamRepository.GetList();
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
                Id = team.Id,
                Name = team.Name,
                HeadName = team.HeadName,
                CreateDate = team.CreateDate,
                EmployeeAmount = team.EmployeeAmount,
                Technologies = team.Technologies,
                ProjectId = team.ProjectId
            };

            return teamDTO;
        }

        public void Update(TeamDTO teamDTO)
            => _teamRepository.Update(new Team()
            {
                Id = teamDTO.Id,
                Name = teamDTO.Name,
                HeadName = teamDTO.HeadName,
                CreateDate = teamDTO.CreateDate,
                EmployeeAmount = teamDTO.EmployeeAmount,
                Technologies = teamDTO.Technologies,
                ProjectId = teamDTO.ProjectId
            });

    }
}
