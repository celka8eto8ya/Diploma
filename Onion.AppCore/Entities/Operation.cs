using System;

namespace Onion.AppCore.Entities
{
   public class Operation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public double Size { get; set; }



        public int ProjectId { get; set; } // foreign key
        public Project Project { get; set; } // navigation property
    }
}
