using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Onion.AppCore.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Authentication> _authenticationRepository;
        private readonly IGenericRepository<PersonalFile> _personalFileRepository;
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IGenericRepository<Team> _teamRepository;

        public EmployeeService(IGenericRepository<Employee> employeeRepository,
            IGenericRepository<Authentication> authenticationRepository,
            IGenericRepository<PersonalFile> personalFileRepository,
            IGenericRepository<Role> roleRepository,
            IGenericRepository<Customer> customerRepository,
            IGenericRepository<Team> teamRepository)
        {
            _employeeRepository = employeeRepository;
            _authenticationRepository = authenticationRepository;
            _personalFileRepository = personalFileRepository;
            _roleRepository = roleRepository;
            _customerRepository = customerRepository;
            _teamRepository = teamRepository;
        }

        public IEnumerable<EmployeeDTO> GetList()
        {
            return _employeeRepository.GetList().Select(x => new EmployeeDTO
            {
                Id = x.Id,
                FullName = x.FullName,
                CreateDate = x.CreateDate,
                TechStackName = x.TechStackName,
                Experience = x.Experience,
                Position = x.Position,
                Technologies = x.Technologies,
                Level = x.Level,
                DepartmentId = x.DepartmentId,
                RoleId = x.RoleId,
                TeamId = x.TeamId
            });
        }

        public string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public bool IsUniqueFullEmployee(FullEmployeeDTO fullEmployeeDTO)
            => _authenticationRepository.GetList().Any(x => x.Email == fullEmployeeDTO.AuthenticationDTO.Email)
            || _employeeRepository.GetList().Any(x => x.FullName == fullEmployeeDTO.EmployeeDTO.FullName);

        public bool IsUniqueEmployee(EmployeeDTO employeeDTO)
           => _employeeRepository.GetList().Any(x => x.FullName == employeeDTO.FullName && x.Id != employeeDTO.Id);





        public void Create(FullEmployeeDTO fullEmployeeDTO)
        {
            Employee employee = _employeeRepository.CreateEntity(new Employee()
            {
                FullName = fullEmployeeDTO.EmployeeDTO.FullName,
                CreateDate = DateTime.Now,
                TechStackName = fullEmployeeDTO.EmployeeDTO.TechStackName,
                Experience = fullEmployeeDTO.EmployeeDTO.Experience,
                Position = fullEmployeeDTO.EmployeeDTO.Position,
                Technologies = fullEmployeeDTO.EmployeeDTO.Technologies,
                Level = fullEmployeeDTO.EmployeeDTO.Level,

                DepartmentId = fullEmployeeDTO.EmployeeDTO.DepartmentId,
                RoleId = fullEmployeeDTO.EmployeeDTO.RoleId
            });

            _authenticationRepository.Create(new Authentication()
            {
                Email = fullEmployeeDTO.AuthenticationDTO.Email,
                Password = CalculateMD5Hash(fullEmployeeDTO.AuthenticationDTO.Password),
                EmployeeId = employee.Id,
            });
            _personalFileRepository.Create(new PersonalFile()
            {
                EmployeeId = employee.Id,
            });
        }

        public void Delete(int id)
        {
            _authenticationRepository.Delete(_authenticationRepository.GetList().First(x => x.EmployeeId == id).Id);
            _employeeRepository.Delete(id);
        }

        public void Update(EmployeeDTO employeeDTO)
            => _employeeRepository.Update(new Employee
            {
                Id = employeeDTO.Id,
                FullName = employeeDTO.FullName,
                CreateDate = employeeDTO.CreateDate,
                TechStackName = employeeDTO.TechStackName,
                Experience = employeeDTO.Experience,
                Position = employeeDTO.Position,
                Technologies = employeeDTO.Technologies,
                Level = employeeDTO.Level,

                DepartmentId = employeeDTO.DepartmentId,
                RoleId = employeeDTO.RoleId,
                TeamId = employeeDTO.TeamId
            });

        public EmployeeDTO GetById(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            return new EmployeeDTO()
            {
                Id = employee.Id,
                FullName = employee.FullName,
                CreateDate = employee.CreateDate,
                TechStackName = employee.TechStackName,
                Experience = employee.Experience,
                Position = employee.Position,
                Technologies = employee.Technologies,
                Level = employee.Level,

                DepartmentId = employee.DepartmentId,
                RoleId = employee.RoleId,
                TeamId = employee.TeamId
            };
        }


        public int GetByEmail(string email)
            => _teamRepository.GetById(
                (int)_employeeRepository.GetById(
                    (int)_authenticationRepository.GetList().First(x => x.Email == email).EmployeeId).TeamId).ProjectId;


        public int GetByEmailEntity(string email)
            => (int)_authenticationRepository.GetList().First(x => x.Email == email).EmployeeId;


        public bool IsExistUser(AuthenticationDTO authenticationDTO)
            => _authenticationRepository.GetList().Any(x => x.Email == authenticationDTO.Email 
                && x.Password == CalculateMD5Hash(authenticationDTO.Password));

        public string CheckRole(string email)
        {
            Authentication authentication = _authenticationRepository.GetList().First(x => x.Email == email);

            if (authentication.EmployeeId != null)
                return _roleRepository.GetById(
                      _employeeRepository.GetById(
                          (int)authentication.EmployeeId).RoleId).Name;
            else
                return _roleRepository.GetById(
                _customerRepository.GetById(
                    (int)authentication.CustomerId).RoleId).Name;
        }


    }
}
