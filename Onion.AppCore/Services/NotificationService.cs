using Onion.AppCore.DTO;
using Onion.AppCore.Entities;
using Onion.AppCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Onion.AppCore.Services
{
    public class NotificationService : INotification
    {
        private readonly IGenericRepository<Notification> _notificationRepository;


        public NotificationService(IGenericRepository<Notification> notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public IEnumerable<NotificationDTO> GetList()
            => _notificationRepository.GetList().Select(x => new NotificationDTO()
            {
                Id = x.Id,
                Topic = x.Topic,
                Text = x.Text,
                CreateDate = x.CreateDate,
                Viewed = x.Viewed,

                ProjectId = x.ProjectId,
                EmployeeId = x.EmployeeId,
                TaskId = x.TaskId
            });

        public void Update(NotificationDTO notificationDTO)
            => _notificationRepository.Update(new Notification
            {
                Id = notificationDTO.Id,
                Topic = notificationDTO.Topic,
                Text = notificationDTO.Text,
                CreateDate = notificationDTO.CreateDate,
                Viewed = notificationDTO.Viewed,

                ProjectId = notificationDTO.ProjectId,
                EmployeeId = notificationDTO.EmployeeId,
                TaskId = notificationDTO.TaskId
            });


        public NotificationDTO GetById(int id)
        {
            Notification notification = _notificationRepository.GetById(id);
            return new NotificationDTO()
            {
                Id = notification.Id,
                Topic = notification.Topic,
                Text = notification.Text,
                CreateDate = notification.CreateDate,
                Viewed = notification.Viewed,

                ProjectId = notification.ProjectId,
                EmployeeId = notification.EmployeeId,
                TaskId = notification.TaskId
            };
        }

    }
}
