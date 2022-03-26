using System;

namespace Onion.AppCore.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        // Name of tech stack (frontend developer)
        public string TechStack { get; set; }
        // Years Amount 
        public double Expirence { get; set; }
        public string Position { get; set; }
        // List hard skills
        public string Technologies { get; set; }
        // Jun, Middle, Senior
        public string Level { get; set; }


        public int DepartmentId { get; set; } // foreign key
        public Department Department { get; set; } // navigation property
    }
}
