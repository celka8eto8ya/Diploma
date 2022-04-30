using System;

namespace Onion.AppCore.Entities
{
    public class Condition
    {
        public int Id { get; set; }
        // Завершен, к реализации, выполняется, к рассмотрению
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
