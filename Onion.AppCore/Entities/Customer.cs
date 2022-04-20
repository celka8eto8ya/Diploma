using System;

namespace Onion.AppCore.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string PhoneNumber { get; set; }
        public double InvestmentAmount { get; set; }
        public double CooperationTime { get; set; }


        public int ProjectId { get; set; } // foreign key
        public Project Project { get; set; } // navigation property
        public int RoleId { get; set; } // foreign key
        public Role Role { get; set; } // navigation property
    }
}
