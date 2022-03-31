using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.AppCore.Interfaces
{
    public interface ITeam
    {
        IEnumerable<Team> GetList(); // получение всех объектов
        TeamDTO GetListProjectsDTO(); // получение всех объектов
        void Create(TeamDTO proj); // создание объекта
        void Update(int id, TeamDTO proj); // обновление объекта
        void Delete(int id); // удаление объекта по id
        TeamDTO GetByIdDTO(int id); // получение одного объекта по id
    }
}
