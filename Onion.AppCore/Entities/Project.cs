using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Onion.AppCore.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime Deadline { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime UpdateDate { get; set; }
        public string TechStack { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public string UseArea { get; set; }


        public int ConditionId { get; set; } // foreign key
        public Condition Condition { get; set; } // navigation property
        public int ReviewStageId { get; set; } // foreign key
        public ReviewStage ReviewStage { get; set; } // navigation property
    }
}
