using System;

namespace Onion.AppCore.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int EmployeeAmount { get; set; }

        public int DepartmentTypeId { get; set; } // foreign key
        public DepartmentType DepartmentType { get; set; } // navigation property
    }
}
