using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IDocument
    {
        IEnumerable<DocumentDTO> GetList();
        void Create(DocumentDTO documentDTO);
        void Delete(int id);
        DocumentDTO GetById(int id);
        bool IsUnique(DocumentDTO documentDTO);
    }
}
