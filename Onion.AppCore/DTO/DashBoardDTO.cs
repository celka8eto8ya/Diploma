using System;
using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
    public class DashBoardDTO
    {
        public int Id { get; set; }
        public DateTime SetDate { get; set; }
        [Required(ErrorMessage = "Enter Start Date, please !")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Enter End Date, please !")]
        public DateTime EndDate { get; set; }


        public int EmployeeId { get; set; } 
    }
}
