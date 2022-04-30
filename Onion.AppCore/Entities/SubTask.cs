using System;

namespace Onion.AppCore.Entities
{
    public class SubTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Comment { get; set; }



        public int? ConditionId { get; set; } // foreign key
        public Condition Condition { get; set; } // navigation property
        public int? ReviewStageId { get; set; } // foreign key
        public ReviewStage ReviewStage { get; set; } // navigation property
        public int? TaskId { get; set; } // foreign key
        public Task Task { get; set; } // navigation property
    }
}
