using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;

namespace Onion.AppCore.Services
{
   public class EmployeeService : IEmployee
    {
        IGenericRepository<Employee> _dbEmployees;
        public EmployeeService(IGenericRepository<Employee> dbEmployees)
        {
            _dbEmployees = dbEmployees;
        }

        public void Create() 
        {
            Employee emp = new Employee()
            { 
            
            };
            _dbEmployees.Create(emp);
        }

    }
}
