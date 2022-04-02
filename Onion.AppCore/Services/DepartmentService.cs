using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;

namespace Onion.AppCore.Services
{
    public class DepartmentService : IDepartment
    {
        private readonly IGenericRepository<Department> _departmentRepository;
        private readonly IGenericRepository<DepartmentType> _departmentTypeRepository;
        public DepartmentService(IGenericRepository<Department> departmentRepository, IGenericRepository<DepartmentType> departmentTypeRepository)
        {
            _departmentRepository = departmentRepository;
            _departmentTypeRepository = departmentTypeRepository;
        }

        public IEnumerable<Department> GetList()
        {
            return _departmentRepository.GetList();
        }

        public void Create(DepartmentDTO departmentDTO)
        {
            Department department = new Department
            {
                Name = departmentDTO.Name,
                Description = departmentDTO.Description,
                CreateDate = DateTime.Now.Date,
                UpdateDate = DateTime.Now.Date,
                EmployeeAmount = 0,
                DepartmentTypeId = departmentDTO.DepartmentTypeId
            };

            _departmentRepository.Create(department);
        }

        public void Delete(int id)
        {
            _departmentRepository.Delete(id);
        }

        public DepartmentDTO GetById(int id)
        {
            Department department = _departmentRepository.GetById(id);
            DepartmentDTO departmentDTO = new DepartmentDTO()
            {
                Name = department.Name,
                Description = department.Description,
                CreateDate = department.CreateDate,
                UpdateDate = department.UpdateDate,
                EmployeeAmount = department.EmployeeAmount
            };

            return departmentDTO;
        }


        public void Update(int id, DepartmentDTO departmentDTO)
        {
            Department department = _departmentRepository.GetById(id);
            if (department != null)
            {

                department.Name = departmentDTO.Name;
                department.Description = departmentDTO.Description;
                department.UpdateDate = DateTime.Now;

                _departmentRepository.Update(department);
            }
        }
        
        public DepartmentDTO GetListDepartmentTypes()
        {
            DepartmentDTO departmentDTO = new DepartmentDTO()
            {
                AllDepartmentTypes = _departmentTypeRepository.GetList()
            };
            return departmentDTO;
        }

    }
}
