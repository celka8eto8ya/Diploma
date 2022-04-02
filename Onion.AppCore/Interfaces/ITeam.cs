using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface ITeam
    {
        IEnumerable<Team> GetList(); 
        TeamDTO GetListTeams(); 
        void Create(TeamDTO teamDTO);
        void Update(int id, TeamDTO teamDTO);
        void Delete(int id);
        TeamDTO GetById(int id); 
    }
}
