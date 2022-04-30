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
    public class InitializingService : IInitializing
    {
        private readonly IGenericRepository<Role> _roleRepository;
        private readonly IGenericRepository<Condition> _conditionRepository;
        private readonly IGenericRepository<ReviewStage> _reviewStageRepository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IGenericRepository<Authentication> _authenticationRepository;


        public InitializingService(IGenericRepository<Role> roleRepository, IGenericRepository<Condition> conditionRepository,
            IGenericRepository<ReviewStage> reviewStageRepository, IGenericRepository<Employee> employeeRepository,
            IGenericRepository<Authentication> authenticationRepository)
        {
            _roleRepository = roleRepository;
            _conditionRepository = conditionRepository;
            _reviewStageRepository = reviewStageRepository;
            _employeeRepository = employeeRepository;
            _authenticationRepository = authenticationRepository;
        }



        public void InitializeRoles()
        {
            if (!_roleRepository.GetList().Any())
            {
                _roleRepository.Create(new Role()
                {
                    Name = Enums.Roles.ProjectManager.ToString(),
                    AccessLevel = Enums.AccessLevels.High.ToString(),
                    CreateDate = DateTime.Now
                });

                _roleRepository.Create(new Role()
                {
                    Name = Enums.Roles.Employee.ToString(),
                    AccessLevel = Enums.AccessLevels.Medium.ToString(),
                    CreateDate = DateTime.Now
                });

                _roleRepository.Create(new Role()
                {
                    Name = Enums.Roles.Customer.ToString(),
                    AccessLevel = Enums.AccessLevels.Low.ToString(),
                    CreateDate = DateTime.Now
                });

                _roleRepository.Create(new Role()
                {
                    Name = Enums.Roles.Admin.ToString(),
                    AccessLevel = Enums.AccessLevels.Setting.ToString(),
                    CreateDate = DateTime.Now
                });
            }
        }

        public void InitializeEmployee()
        {
            if (!_employeeRepository.GetList().Any())
            {
                Employee employee = _employeeRepository.CreateEntity(new Employee()
                {
                    FullName = BankData.AdminFullName,
                    CreateDate = DateTime.Now,
                    TechStackName = BankData.AdminFullName,
                    Position = BankData.AdminFullName,
                    Level = BankData.AdminFullName,

                    RoleId = _roleRepository.GetList().First(x => x.Name == Enums.Roles.Admin.ToString()).Id
                });

                MD5 md5 = MD5.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(BankData.AdminPassword);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                string password = sb.ToString();

                _authenticationRepository.Create(new Authentication()
                {
                    Email = BankData.AdminLogin,
                    Password = password,
                    EmployeeId = employee.Id,
                });
            }
        }

        public void InitializeConditions()
        {
            if (!_conditionRepository.GetList().Any())
            {
                _conditionRepository.Create(new Condition()
                {
                    Name = Enums.Conditions.Completed.ToString(),
                    CreateDate = DateTime.Now
                });

                _conditionRepository.Create(new Condition()
                {
                    Name = Enums.Conditions.ForConsideration.ToString(),
                    CreateDate = DateTime.Now
                });

                _conditionRepository.Create(new Condition()
                {
                    Name = Enums.Conditions.ForImplementation.ToString(),
                    CreateDate = DateTime.Now
                });

                _conditionRepository.Create(new Condition()
                {
                    Name = Enums.Conditions.InProgress.ToString(),
                    CreateDate = DateTime.Now
                });
            }
        }

        public void InitializeReviewStages()
        {
            if (!_reviewStageRepository.GetList().Any())
            {
                _reviewStageRepository.Create(new ReviewStage()
                {
                    Name = Enums.ReviewStages.Accepted.ToString(),
                    CreateDate = DateTime.Now
                });

                _reviewStageRepository.Create(new ReviewStage()
                {
                    Name = Enums.ReviewStages.ForConsideration.ToString(),
                    CreateDate = DateTime.Now
                });

                _reviewStageRepository.Create(new ReviewStage()
                {
                    Name = Enums.ReviewStages.ForRevision.ToString(),
                    CreateDate = DateTime.Now
                });

                _reviewStageRepository.Create(new ReviewStage()
                {
                    Name = Enums.ReviewStages.None.ToString(),
                    CreateDate = DateTime.Now
                });
            }
        }



        public void Initialize()
        {
            InitializeRoles();
            InitializeConditions();
            InitializeReviewStages();
            InitializeEmployee();
        }
    }
}
