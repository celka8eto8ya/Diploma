using System;

namespace Onion.AppCore.Entities
{
   public class Task
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


       
        public int? ConditionId { get; set; } // foreign key
        public Condition Condition { get; set; } // navigation property
        public int? ReviewStageId { get; set; } // foreign key
        public ReviewStage ReviewStage { get; set; } // navigation property
        public int? EmployeeId { get; set; } // foreign key
        public Employee Employee { get; set; } // navigation property
        public int? StepId { get; set; } // foreign key
        public Step Step { get; set; } // navigation property
    }
}
