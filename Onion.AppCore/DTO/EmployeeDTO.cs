using System;
using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Enter Full Name, please !")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Name length is [8;30] !")]
        public string FullName { get; set; }
        public DateTime CreateDate { get; set; }
       
        [Required(ErrorMessage = "Enter Tech. Stack, please !")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Tech. Stack length is [2;30] !")]
        public string TechStackName { get; set; }
        public double Experience { get; set; }
        
        [Required(ErrorMessage = "Enter Position, please !")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Position length is [2;30] !")]
        public string Position { get; set; }
        public string Technologies { get; set; }
        public string Level { get; set; }


        public int? DepartmentId { get; set; }
        public int RoleId { get; set; }
        public int? TeamId { get; set; }
    }
}
