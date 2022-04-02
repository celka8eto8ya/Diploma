using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;

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
        {
            return _departmentTypeRepository.GetList();
        }

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
        {
            _departmentTypeRepository.Delete(id);
        }

        public DepartmentTypeDTO GetById(int id)
        {
            DepartmentType departmentType = _departmentTypeRepository.GetById(id);
            DepartmentTypeDTO departmentTypeDTO = new DepartmentTypeDTO()
            {
                Name = departmentType.Name,
                Functions = departmentType.Functions,
                Description = departmentType.Description,
                CreateDate = departmentType.CreateDate,
                UpdateDate = departmentType.UpdateDate
            };

            return departmentTypeDTO;
        }


        public void Update(int id, DepartmentTypeDTO departmentTypeDTO)
        {
            DepartmentType departmentType = _departmentTypeRepository.GetById(id);
            if (departmentType != null)
            {
                departmentType.Name = departmentTypeDTO.Name;
                departmentType.Functions = departmentTypeDTO.Functions;
                departmentType.Description = departmentTypeDTO.Description;
                departmentType.UpdateDate = DateTime.Now;

                _departmentTypeRepository.Update(departmentType);
            }
        }

    }
}
