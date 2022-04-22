using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.AppCore.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public double Cost { get; set; }
        public string Comment { get; set; }
        public int Complexity { get; set; }



        public int? ConditionId { get; set; } 
        public int? ReviewStageId { get; set; }
        public int? EmployeeId { get; set; } 
        public int? StepId { get; set; } 
    }
}
