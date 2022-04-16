using System;

namespace Onion.AppCore.Entities
{
    public class ReviewStage
    {
        public int Id { get; set; }
        // принято, на доработку, к рассмотрению, none
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
