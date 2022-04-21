using System;
using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name, please !")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Name length is [10;100] !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Address, please !")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Name length is [10;100] !")]
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }

        [StringLength(40, MinimumLength = 9, ErrorMessage = "Phone Number length is [9;40] !")]
        [Required(ErrorMessage = "Enter Phone Number, please !")]
        [RegularExpression(@"[+]{1}[0-9]*", ErrorMessage = "Not Correct Phone Number !")]
        public string PhoneNumber { get; set; }
       
        [Range(0, 10000000000)]
        public double InvestmentAmount { get; set; }

        [Range(0, 1000)]
        public double CooperationTime { get; set; }


        public string ProjectName { get; set; }

        public int ProjectId { get; set; }
        public int RoleId { get; set; }
    }
}
