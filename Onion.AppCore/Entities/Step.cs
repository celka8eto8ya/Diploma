
namespace Onion.AppCore.Entities
{
    public class Step
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TechStack { get; set; }
        public int TaskAmount { get; set; }
        public double PercentCompletionTasks { get; set; }
        public int AmountCompletionTasks { get; set; }


        public int? ProjectId { get; set; } // foreign key
        public Project Project { get; set; } // navigation property
        public int? ConditionId { get; set; } // foreign key
        public Condition Condition { get; set; } // navigation property
        public int? ReviewStageId { get; set; } // foreign key
        public ReviewStage ReviewStage { get; set; } // navigation property
    }
}
