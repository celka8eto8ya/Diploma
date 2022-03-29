using System;

namespace Onion.AppCore.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string EmployeeAmount { get; set; }
    }
}
