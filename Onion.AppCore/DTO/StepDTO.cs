using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
    public class StepDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Name, please !")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Name length is [8;100] !")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter Tech. Stack, please !")]
        public string TechStack { get; set; }
        public int TaskAmount { get; set; }
        public double PercentCompletionTasks { get; set; }
        public int AmountCompletionTasks { get; set; }


        public int? ProjectId { get; set; } // foreign key
        public int? ConditionId { get; set; } // foreign key
        public int? ReviewStageId { get; set; } // foreign key
    }
}
