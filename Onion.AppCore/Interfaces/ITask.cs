using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
   public interface ITask
    {
        IEnumerable<FullTaskDTO> GetList();
        Task Create(TaskDTO taskDTO);
        void Update(TaskDTO taskDTO);
        void Delete(int id);
        TaskDTO GetById(int id);
        bool IsUniqueTask(TaskDTO taskDTO);
        void SetTask(int taskId, int id);
        void UpdateCondition(int taskId, string role, int projectId, string email, string command);
    }
}
