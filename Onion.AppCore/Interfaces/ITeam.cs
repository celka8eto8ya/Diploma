using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface ITeam
    {
        IEnumerable<Team> GetList(); 
        void Create(TeamDTO teamDTO);
        void Update(TeamDTO teamDTO);
        void Delete(int id);
        TeamDTO GetById(int id); 
    }
}
