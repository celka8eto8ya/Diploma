using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class DepartmentTypeService : IDepartmentType
    {
        private readonly IGenericRepository<DepartmentType> _departmentTypeRepository;

        public DepartmentTypeService(IGenericRepository<DepartmentType> departmentTypeRepository)
        {
            _departmentTypeRepository = departmentTypeRepository;
        }

        public IEnumerable<DepartmentType> GetList()
            => _departmentTypeRepository.GetList();


        public void Create(DepartmentTypeDTO departmentTypeDTO)
        {
            DepartmentType departmentType = new DepartmentType
            {
                Name = departmentTypeDTO.Name,
                Functions = departmentTypeDTO.Functions,
                Description = departmentTypeDTO.Description,
                CreateDate = DateTime.Now.Date,
                UpdateDate = DateTime.Now.Date
            };

            _departmentTypeRepository.Create(departmentType);
        }

        public void Delete(int id)
            => _departmentTypeRepository.Delete(id);


        public DepartmentTypeDTO GetById(int id)
        {
            DepartmentType departmentType = _departmentTypeRepository.GetById(id);
            DepartmentTypeDTO departmentTypeDTO = new DepartmentTypeDTO()
            {
                Id = departmentType.Id,
                Name = departmentType.Name,
                Functions = departmentType.Functions,
                Description = departmentType.Description,
                UpdateDate = departmentType.UpdateDate,
                CreateDate = departmentType.CreateDate
            };

            return departmentTypeDTO;
        }


        public void Update(DepartmentTypeDTO departmentTypeDTO)
            => _departmentTypeRepository.Update(new DepartmentType()
            {

                Id = departmentTypeDTO.Id,
                Name = departmentTypeDTO.Name,
                Functions = departmentTypeDTO.Functions,
                Description = departmentTypeDTO.Description,
                UpdateDate = DateTime.Now,
                CreateDate = departmentTypeDTO.CreateDate
            });

        public bool IsUnique(DepartmentTypeDTO departmentTypeDTO)
            => _departmentTypeRepository.GetList().Any(x => x.Name == departmentTypeDTO.Name && x.Id != departmentTypeDTO.Id);
    }
}
