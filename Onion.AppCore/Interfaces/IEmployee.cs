using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<EmployeeDTO> GetList();
        void Create(FullEmployeeDTO fullEmployeeDTO);
        bool UniqueEmail(FullEmployeeDTO fullEmployeeDTO);
    }
}
