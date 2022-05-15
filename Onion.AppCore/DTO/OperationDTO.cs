using System;

namespace Onion.AppCore.DTO
{
    public class OperationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Object { get; set; }


        public int ProjectId { get; set; }
    }
}
