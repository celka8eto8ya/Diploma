using System;

namespace Onion.AppCore.Entities
{
    public class DashBoard
    {
        public int Id { get; set; }
        public DateTime SetDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public int EmployeeId { get; set; } 
        public Employee Employee { get; set; }

    }
}
