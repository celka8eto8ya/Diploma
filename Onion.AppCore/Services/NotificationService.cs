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
        private readonly IGenericRepository<Task> _taskRepository;


        public NotificationService(IGenericRepository<Notification> notificationRepository, IGenericRepository<Task> taskRepository)
        {
            _notificationRepository = notificationRepository;
            _taskRepository = taskRepository;
        }

        public IEnumerable<NotificationDTO> GetList()
            => _notificationRepository.GetList().Select(x => new NotificationDTO()
            {
                Id = x.Id,
                Topic = x.Topic,
                Text = x.Text,
                CreateDate = x.CreateDate,
                Viewed = x.Viewed,
                TaskName = _taskRepository.GetById(x.TaskId).Name,
                StepId = _taskRepository.GetById(x.TaskId).StepId,

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
