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
        public DepartmentService(IGenericRepository<Department> departmentRepository)
        {
            _departmentRepository = departmentRepository;
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
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                UpdateDate = department.UpdateDate,
                CreateDate = department.CreateDate,
                EmployeeAmount = department.EmployeeAmount,
                DepartmentTypeId = department.DepartmentTypeId
            };

            return departmentDTO;
        }


        public void Update(DepartmentDTO departmentDTO) =>
            _departmentRepository.Update(new Department
            {
                Id = departmentDTO.Id,
                Name = departmentDTO.Name,
                Description = departmentDTO.Description,
                UpdateDate = DateTime.Now,
                CreateDate = departmentDTO.CreateDate,
                EmployeeAmount = departmentDTO.EmployeeAmount,
                DepartmentTypeId = departmentDTO.DepartmentTypeId
            });

    }
}
