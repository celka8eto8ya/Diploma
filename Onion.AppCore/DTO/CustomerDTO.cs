using System;

namespace Onion.AppCore.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string PhoneNumber { get; set; }
        public double InvestmentAmount { get; set; }
        public double CooperationTime { get; set; }


        public int ProjectId { get; set; } 
        public int RoleId { get; set; }
    }
}
