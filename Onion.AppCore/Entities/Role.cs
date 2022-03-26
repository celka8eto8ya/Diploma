using System;

namespace Onion.AppCore.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // F e high, medium, low
        public string AccessLevel { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }


        public int EmployeeId { get; set; } // foreign key
        public Employee Employee { get; set; } // navigation property
    }
}
