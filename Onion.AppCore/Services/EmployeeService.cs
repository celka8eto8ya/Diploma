using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;

namespace Onion.AppCore.Services
{
   public class EmployeeService : IEmployee
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        public EmployeeService(IGenericRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void Create() 
        {
            Employee emp = new Employee()
            { 
            
            };
            _employeeRepository.Create(emp);
        }

    }
}
