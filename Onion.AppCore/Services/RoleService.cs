using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class RoleService : IRole
    {
        private readonly IGenericRepository<Role> _roleRepository;

        public RoleService(IGenericRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }



        public void Initialize()
        {
            if (!_roleRepository.GetList().Any())
            {
                _roleRepository.Create(new Role()
                {
                    Name = "Project Manager",
                    AccessLevel = "High"
                });

                _roleRepository.Create(new Role()
                {
                    Name = "Employee",
                    AccessLevel = "Medium"
                });

                _roleRepository.Create(new Role()
                {
                    Name = "Customer",
                    AccessLevel = "Low"
                });
            }
        }

    }
}
