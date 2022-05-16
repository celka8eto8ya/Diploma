using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface IDocument
    {
        IEnumerable<DocumentDTO> GetList();
        Document Create(DocumentDTO documentDTO);
        void Delete(int id);
        DocumentDTO GetById(int id);
        bool IsUnique(DocumentDTO documentDTO);
    }
}
