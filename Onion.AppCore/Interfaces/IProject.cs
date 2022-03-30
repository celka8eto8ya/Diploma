using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IProject
    {
        IEnumerable<Project> GetList(); // получение всех объектов
        ProjectDTO GetByIdDTO(int id); // получение одного объекта по id
        Project GetById(int id); // получение одного объекта по id
        void Create(ProjectDTO proj); // создание объекта
        void Update(int id, ProjectDTO proj); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
