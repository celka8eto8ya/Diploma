﻿using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<EmployeeDTO> GetList();
        void Create(FullEmployeeDTO fullEmployeeDTO);
        bool UniqueEmployee(FullEmployeeDTO fullEmployeeDTO);
        void Delete(int id);
        void Update(EmployeeDTO employeeDTO);
        EmployeeDTO GetById(int id);
    }
}
