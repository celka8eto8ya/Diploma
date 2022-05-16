using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface ITeam
    {
        IEnumerable<Team> GetList(); 
        Team Create(TeamDTO teamDTO);
        void Update(TeamDTO teamDTO);
        void Delete(int id);
        TeamDTO GetById(int id);
        bool IsUnique(TeamDTO teamDTO);
    }
}
