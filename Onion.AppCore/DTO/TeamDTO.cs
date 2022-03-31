using Onion.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Onion.AppCore.DTO
{
   public class TeamDTO
    {
        [Required(ErrorMessage = "Enter Name, please !")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Name length is [5;30] !")]
        public string Name { get; set; }
        public string HeadName { get; set; }
        public DateTime CreateDate { get; set; }
        public int EmployeeAmount { get; set; }
        // List hard skills
        public string Technologies { get; set; }
        public IEnumerable<Project> AllProjects { get; set; }

        
        [Required(ErrorMessage = "Enter Project Name, please !")]
        public int ProjectId { get; set; } // foreign key

    }
}
