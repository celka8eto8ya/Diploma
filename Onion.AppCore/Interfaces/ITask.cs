using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
   public interface ITask
    {
        IEnumerable<FullTaskDTO> GetList();
        void Create(TaskDTO taskDTO);
        void Update(TaskDTO taskDTO);
        void Delete(int id);
        TaskDTO GetById(int id);
        bool IsUniqueTask(TaskDTO taskDTO);
        void SetTask(int taskId, int id);
    }
}
