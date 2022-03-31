using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Onion.AppCore.Services
{
    public class DepartmentTypeService : IDepartmentType
    {
        IGenericRepository<DepartmentType> _DepartmentTypes;
        public DepartmentTypeService(IGenericRepository<DepartmentType> DepartmentTypes)
        {
            _DepartmentTypes = DepartmentTypes;
        }

        public IEnumerable<DepartmentType> GetList()
        {
            return _DepartmentTypes.GetList();
        }

        public void Create(DepartmentTypeDTO depType)
        {
            DepartmentType departmentType = new DepartmentType
            {
                Name = depType.Name,
                Functions = depType.Functions,
                Description = depType.Description,
                CreateDate = DateTime.Now.Date,
                UpdateDate = DateTime.Now.Date
            };

            _DepartmentTypes.Create(departmentType);
        }

        public void Delete(int id)
        {
            _DepartmentTypes.Delete(id);
        }

        public DepartmentTypeDTO GetByIdDTO(int id)
        {
            DepartmentType depType = _DepartmentTypes.GetById(id);
            DepartmentTypeDTO departmentType = new DepartmentTypeDTO()
            {
                Name = depType.Name,
                Functions = depType.Functions,
                Description = depType.Description,
                CreateDate = depType.CreateDate,
                UpdateDate = depType.UpdateDate
            };

            return departmentType;
        }


        public void Update(int id, DepartmentTypeDTO depType)
        {
            DepartmentType departmentType = _DepartmentTypes.GetById(id);
            if (departmentType != null)
            {
                departmentType.Name = depType.Name;
                departmentType.Functions = depType.Functions;
                departmentType.Description = depType.Description;
                departmentType.UpdateDate = DateTime.Now;

                _DepartmentTypes.Update(departmentType);
            }
        }
    }
}
