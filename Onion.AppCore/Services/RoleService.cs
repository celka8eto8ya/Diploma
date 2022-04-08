using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
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

        public IEnumerable<RoleDTO> GetList()
        {
            return _roleRepository.GetList().Select(x => new RoleDTO
            {
                Id = x.Id,
                Name = x.Name,
                AccessLevel = x.AccessLevel,
                CreateDate = x.CreateDate,
            });
        }

    }
}
