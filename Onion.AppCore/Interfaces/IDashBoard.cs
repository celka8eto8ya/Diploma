using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IDashBoard
    {
        IEnumerable<DashBoardDTO> GetList();
        void Create(DashBoardDTO dashBoardDTO, int teamId);
        IEnumerable<FullDashBoardDTO> GetFullList();
        void Delete(int id);
    }
}
