using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IPersonalFile
    {
        void Update(PersonalFileDTO personalFileDTO);
        PersonalFileDTO GetByEmployeeId(int id);
    }
}
