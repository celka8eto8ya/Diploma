using System;

namespace Onion.AppCore.DTO
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Viewed { get; set; }
        public string TaskName { get; set; }
        public int? StepId { get; set; }



        public int ProjectId { get; set; } 
        public int? EmployeeId { get; set; } 
        public int TaskId { get; set; } 
    }
}
