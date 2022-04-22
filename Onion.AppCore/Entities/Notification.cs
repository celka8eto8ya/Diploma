using System;

namespace Onion.AppCore.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }



        public int ProjectId { get; set; } // foreign key
        public Project Project { get; set; } // navigation property
        public int? EmployeeId { get; set; } // foreign key
        public Employee Employee { get; set; } // navigation property
        public int TaskId { get; set; } // foreign key
        public Task Task { get; set; } // navigation property
    }
}
