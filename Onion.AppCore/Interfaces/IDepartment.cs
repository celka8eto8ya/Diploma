using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.AppCore.Interfaces
{
     public interface IDepartment
    {
        IEnumerable<Department> GetList(); // получение всех объектов
        DepartmentDTO GetByIdDTO(int id); // получение одного объекта по id
        void Create(DepartmentDTO proj); // создание объекта
        void Update(int id, DepartmentDTO proj); // обновление объекта
        void Delete(int id); // удаление объекта по id
        DepartmentDTO GetListDepTypesDTO(); // получение всех объектов
    }
}
