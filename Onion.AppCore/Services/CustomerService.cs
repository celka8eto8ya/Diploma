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
    public class CustomerService : ICustomer
    {
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IGenericRepository<Authentication> _authenticationRepository;
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IGenericRepository<Project> _projectRepository;

        public CustomerService(IGenericRepository<Customer> customerRepository,
            IGenericRepository<Authentication> authenticationRepository,
            IGenericRepository<Role> roleRepository,
            IGenericRepository<Project> projectRepository)
        {
            _customerRepository = customerRepository;
            _authenticationRepository = authenticationRepository;
            _roleRepository = roleRepository;
            _projectRepository = projectRepository;
        }

        public IEnumerable<CustomerDTO> GetList()
        {
            var projects = _projectRepository.GetList();
            return _customerRepository.GetList().Select(x => new CustomerDTO
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                PhoneNumber = x.PhoneNumber,
                CreateDate = x.CreateDate,
                UpdateDate = x.UpdateDate,
                InvestmentAmount = x.InvestmentAmount,
                CooperationTime = x.CooperationTime,

                ProjectName = projects.First(y => y.Id == x.ProjectId).Name,
                ProjectId = x.ProjectId,
                RoleId = x.RoleId
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

        public bool IsUniqueFullCustomer(FullCustomerDTO fullCustomerDTO)
            => _authenticationRepository.GetList().Any(x => x.Email == fullCustomerDTO.AuthenticationDTO.Email)
            || _customerRepository.GetList().Any(x => x.Name == fullCustomerDTO.CustomerDTO.Name);

        public bool IsUniqueCustomer(CustomerDTO customerDTO)
           => _customerRepository.GetList().Any(x => x.Name == customerDTO.Name && x.Id != customerDTO.Id);





        public void Create(FullCustomerDTO fullCustomerDTO)
        {
            Customer customer = _customerRepository.CreateEntity(new Customer()
            {
                Name = fullCustomerDTO.CustomerDTO.Name,
                Address = fullCustomerDTO.CustomerDTO.Address,
                PhoneNumber = fullCustomerDTO.CustomerDTO.PhoneNumber,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                InvestmentAmount = fullCustomerDTO.CustomerDTO.InvestmentAmount,
                CooperationTime = fullCustomerDTO.CustomerDTO.CooperationTime,

                ProjectId = fullCustomerDTO.CustomerDTO.ProjectId,
                RoleId = _roleRepository.GetList().First(x => x.Name == Enums.Roles.Customer.ToString()).Id
            });

            _authenticationRepository.Create(new Authentication()
            {
                Email = fullCustomerDTO.AuthenticationDTO.Email,
                Password = CalculateMD5Hash(fullCustomerDTO.AuthenticationDTO.Password),
                CustomerId = customer.Id
            });

        }

        public void Delete(int id)
        {
            _authenticationRepository.Delete(_authenticationRepository.GetList().First(x => x.CustomerId == id).Id);
            _customerRepository.Delete(id);
        }

        public void Update(CustomerDTO customerDTO)
            => _customerRepository.Update(new Customer
            {
                Id = customerDTO.Id,
                Name = customerDTO.Name,
                Address = customerDTO.Address,
                PhoneNumber = customerDTO.PhoneNumber,
                CreateDate = customerDTO.CreateDate,
                UpdateDate = DateTime.Now,
                InvestmentAmount = customerDTO.InvestmentAmount,
                CooperationTime = customerDTO.CooperationTime,

                ProjectId = customerDTO.ProjectId,
                RoleId = customerDTO.RoleId
            });

        public CustomerDTO GetById(int id)
        {
            Customer customer = _customerRepository.GetById(id);
            return new CustomerDTO()
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                PhoneNumber = customer.PhoneNumber,
                CreateDate = customer.CreateDate,
                UpdateDate = customer.UpdateDate,
                InvestmentAmount = customer.InvestmentAmount,
                CooperationTime = customer.CooperationTime,

                ProjectId = customer.ProjectId,
                RoleId = customer.RoleId
            };
        }
    }
}
