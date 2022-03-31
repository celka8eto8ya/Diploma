using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.AppCore.Interfaces
{
    public interface IDepartmentType
    {
        IEnumerable<DepartmentType> GetList(); // получение всех объектов
        DepartmentTypeDTO GetByIdDTO(int id); // получение одного объекта по id
        void Create(DepartmentTypeDTO depType); // создание объекта
        void Update(int id, DepartmentTypeDTO depType); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
