using Onion.AppCore.DTO;
using System.Collections.Generic;

namespace Onion.AppCore.Interfaces
{
    public interface INotification
    {
        IEnumerable<NotificationDTO> GetList();
        void Update(NotificationDTO notificationDTO);
        NotificationDTO GetById(int id);
    }
}
