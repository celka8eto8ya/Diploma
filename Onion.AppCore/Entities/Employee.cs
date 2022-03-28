using System;

namespace Onion.AppCore.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime CreateDate { get; set; }
        // Name of tech stack (frontend developer)
        public string TechStackName { get; set; }
        // Years Amount 
        public double Experience { get; set; }
        public string Position { get; set; }
        // List hard skills
        public string Technologies { get; set; }
        // Jun, Middle, Senior
        public string Level { get; set; }


        public int DepartmentId { get; set; } // foreign key
        public Department Department { get; set; } // navigation property
        public int TeamId { get; set; } // foreign key
        public Team Team { get; set; } // navigation property
    }
}
