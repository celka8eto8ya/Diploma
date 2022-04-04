using System;

namespace Onion.AppCore.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HeadName { get; set; }
        public DateTime CreateDate { get; set; }
        public int EmployeeAmount { get; set; }
        public string Technologies { get; set; }


        public int ProjectId { get; set; } // foreign key
        public Project Project { get; set; } // navigation property
    }
}
