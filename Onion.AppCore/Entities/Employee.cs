using System;
using System.Collections.Generic;
using System.Text;

namespace Onion.AppCore.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }

        //public byte[] File { get; set; }
        //public string FileType { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime AddDate { get; set; } // Auto
        //public string Author { get; set; }
        //public string Adder { get; set; } // Auto
        //public string Description { get; set; }
        //public string Language { get; set; } // In moment may be only One language
        //public bool CurrentVersion { get; set; }
        //public int VersionId { get; set; }


        public int ProjectId { get; set; } // foreign key
        public Project Project { get; set; } // navigation property
    }
}
