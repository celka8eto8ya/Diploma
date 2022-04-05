using System;

namespace Onion.AppCore.Entities
{
    public class Role
    {
        public int Id { get; set; }
        // PM, employee, customer, 
        public string Name { get; set; }
        // For example: high, medium, low (0, 1, 2)
        public string AccessLevel { get; set; }
        public DateTime SetDate { get; set; }
    }
}
