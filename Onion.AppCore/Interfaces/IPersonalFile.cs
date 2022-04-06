using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IPersonalFile
    {
        IEnumerable<PersonalFileDTO> GetList();
        void Update(PersonalFileDTO personalFileDTO);
    }
}
