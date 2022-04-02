using System;

namespace Onion.AppCore.Entities
{
    public class Condition
    {
        public int Id { get; set; }
        // Завершен, к реализации, выполняется, к рассмотрению
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime SetDate { get; set; }
        // принято, на доработку, к рассмотрению
        public string ReviewStage { get; set; }


        public int ProjectId { get; set; } // foreign key
        public Project Project { get; set; } // navigation property
        public int StepId { get; set; } // foreign key
        //public Step Step { get; set; } // navigation property
        public int TaskId { get; set; } // foreign key
        //public Task Task { get; set; } // navigation property
        public int SubTaskId { get; set; } // foreign key
        //public SubTask SubTask { get; set; } // navigation property
    }
}
