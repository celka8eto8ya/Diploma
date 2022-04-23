using System;
using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name, please !")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Name length is [8;100] !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter Deadline, please !")]
        public DateTime Deadline { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public double Cost { get; set; }
        public string Comment { get; set; }
        [Required(ErrorMessage = "Enter Complexity, please !")]
        [Range(1, 5)]
        public int Complexity { get; set; }



        public int? ConditionId { get; set; } 
        public int? ReviewStageId { get; set; }
        public int? EmployeeId { get; set; } 
        public int? StepId { get; set; } 
    }
}
