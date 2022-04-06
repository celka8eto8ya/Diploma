using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
   public interface IRole
    {
        void Initialize();
        IEnumerable<RoleDTO> GetList();
    }
}
