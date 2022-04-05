using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.AppCore.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime CreateDate { get; set; }
        public string TechStackName { get; set; }
        public double Experience { get; set; }
        public string Position { get; set; }
        public string Technologies { get; set; }
        public string Level { get; set; }


        public int DepartmentId { get; set; }
        public int RoletId { get; set; }
    }
}
