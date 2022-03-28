using System;

namespace Onion.AppCore.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string TechStack { get; set; }
        public int EmployeeAmount { get; set; }
        public double Cost { get; set; }
        // File .doc
        public string Instruction { get; set; }
        public string UseArea { get; set; }

    }
}
