using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.AppCore.Interfaces
{
    public interface IGenericRepository<T>
        where T : class
    {
        IEnumerable<T> GetList(); // получение всех объектов
        T GetById(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
    }
}
