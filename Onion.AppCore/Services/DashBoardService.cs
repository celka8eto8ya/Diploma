using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class DashBoardService : IDashBoard
    {
        private readonly IGenericRepository<DashBoard> _dashBoardRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Team> _teamRepository;
        private readonly IGenericRepository<Project> _projectRepository;

        public DashBoardService(IGenericRepository<DashBoard> dashBoardRepository, IGenericRepository<Employee> employeeRepository,
            IGenericRepository<Team> teamRepository, IGenericRepository<Project> projectRepository)
        {
            _dashBoardRepository = dashBoardRepository;
            _employeeRepository = employeeRepository;
            _teamRepository = teamRepository;
            _projectRepository = projectRepository;
        }


        public IEnumerable<DashBoardDTO> GetList()
            => _dashBoardRepository.GetList().Select(x => new DashBoardDTO()
            {
                Id = x.Id,
                SetDate = x.SetDate,
                StartDate = x.StartDate,
                EndDate = x.EndDate,

                EmployeeId = x.EmployeeId
            });

        public void Create(DashBoardDTO dashBoardDTO, int teamId)
        {
            Employee employee0 = _employeeRepository.GetById(dashBoardDTO.EmployeeId);
            employee0.TeamId = teamId;
            _employeeRepository.Update(employee0);

            _dashBoardRepository.Create(new DashBoard()
            {
                SetDate = DateTime.Now,
                StartDate = dashBoardDTO.StartDate,
                EndDate = dashBoardDTO.EndDate,

                EmployeeId = dashBoardDTO.EmployeeId
            });
        }

        public IEnumerable<FullDashBoardDTO> GetFullList()
            => _dashBoardRepository.GetList().Select(x => new FullDashBoardDTO()
            {
                Id = x.Id,
                SetDate = x.SetDate,
                StartDate = x.StartDate,
                EndDate = x.EndDate,

                Employee = _employeeRepository.GetById(x.EmployeeId).FullName,
                Team = _teamRepository.GetById((int)_employeeRepository.GetById(x.EmployeeId).TeamId).Name,
                Project = _projectRepository.GetById(_teamRepository.GetById((int)_employeeRepository.GetById(x.EmployeeId).TeamId).ProjectId).Name
            });

        public void Delete(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            employee.TeamId = null;
            _employeeRepository.Update(employee);

            _dashBoardRepository.Delete(
                _dashBoardRepository.GetList().First(x => x.EmployeeId == id).Id);
        }


    }
}
