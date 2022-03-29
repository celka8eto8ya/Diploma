using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IProject
    {
        IEnumerable<Project> GetList(); // получение всех объектов
        Project GetById(int id); // получение одного объекта по id
        void Create(Project proj); // создание объекта
        void Update(Project proj); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
