﻿using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Onion.AppCore.Services
{
    public class InitializingService : IInitializing
    {
        private readonly IGenericRepository<Role> _roleRepository;

        public InitializingService(IGenericRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }



        public void InitializeRoles()
        {
            if (!_roleRepository.GetList().Any())
            {
                _roleRepository.Create(new Role()
                {
                    Name = Enums.Roles.ProjectManager.ToString(),
                    AccessLevel = Enums.AccessLevel.High.ToString(),
                    CreateDate = DateTime.Now
                });

                _roleRepository.Create(new Role()
                {
                    Name = Enums.Roles.Employee.ToString(),
                    AccessLevel = Enums.AccessLevel.Medium.ToString(),
                    CreateDate = DateTime.Now
                });

                _roleRepository.Create(new Role()
                {
                    Name = Enums.Roles.Customer.ToString(),
                    AccessLevel = Enums.AccessLevel.Low.ToString(),
                    CreateDate = DateTime.Now
                });
            }
        }

        public void InitializeEmployee()
        {
            
        }



    }
}
