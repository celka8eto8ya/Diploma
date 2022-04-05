using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System.Collections.Generic;

namespace Onion.AppCore.Services
{
   public class EmployeeService : IEmployee
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        public EmployeeService(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetList()
        {
            return _employeeRepository.GetList();
        }

        public void Create(EmployeeDTO employeeDTO)
        {
            Employee employee = new Employee
            {
                //Name = employeeDTO.Name,
                //Description = employeeDTO.Description,
                //CreateDate = employeeDTO.Now.Date,
                //UpdateDate = employeeDTO.Now.Date,
                //EmployeeAmount = 0,
                //DepartmentTypeId = employeeDTO.DepartmentTypeId
            };

            _employeeRepository.Create(employee);
        }

    }
}
