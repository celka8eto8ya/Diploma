using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IOperation
    {
        IEnumerable<OperationDTO> GetList();
        void Create(string type, string object0, string name, string author, int projectId);
        byte[] ExportToWord(IEnumerable<OperationDTO> operationDTO);
        byte[] ExportToXML(IEnumerable<OperationDTO> operationDTO);
    }
}
