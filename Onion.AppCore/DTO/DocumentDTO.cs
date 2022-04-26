using System;

namespace Onion.AppCore.DTO
{
    public class DocumentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] File { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime AddDate { get; set; }
        public string Adder { get; set; }
        public double Size { get; set; }



        public int ProjectId { get; set; } 
    }
}
