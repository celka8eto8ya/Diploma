using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.AppCore.Services
{
    public class DepartmentService : IDepartment
    {
        IGenericRepository<Department> _Departments;
        IGenericRepository<DepartmentType> _DepTypes;
        public DepartmentService(IGenericRepository<Department> Departments, IGenericRepository<DepartmentType> DepTypes)
        {
            _Departments = Departments;
            _DepTypes = DepTypes;
        }

        public IEnumerable<Department> GetList()
        {
            return _Departments.GetList();
        }

        public void Create(DepartmentDTO dep)
        {
            Department department = new Department
            {
                Name = dep.Name,
                Description = dep.Description,
                CreateDate = DateTime.Now.Date,
                UpdateDate = DateTime.Now.Date,
                EmployeeAmount = 0,
                DepartmentTypeId = dep.DepartmentTypeId
            };

            _Departments.Create(department);
        }

        public void Delete(int id)
        {
            _Departments.Delete(id);
        }

        public DepartmentDTO GetByIdDTO(int id)
        {
            Department dep = _Departments.GetById(id);
            DepartmentDTO department = new DepartmentDTO()
            {
                Name = dep.Name,
                Description = dep.Description,
                CreateDate = dep.CreateDate,
                UpdateDate = dep.UpdateDate,
                EmployeeAmount = dep.EmployeeAmount
            };

            return department;
        }



        public void Update(int id, DepartmentDTO dep)
        {
            Department department = _Departments.GetById(id);
            if (department != null)
            {

                department.Name = dep.Name;
                department.Description = dep.Description;
                department.UpdateDate = DateTime.Now;

                _Departments.Update(department);
            }
        }

        public DepartmentDTO GetListDepTypesDTO()
        {
            DepartmentDTO dep = new DepartmentDTO()
            {
                AllDepartmentTypes = _DepTypes.GetList()
            };
            return dep;
        }

    }
}
