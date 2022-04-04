using Onion.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
   public class TeamDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name, please !")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Name length is [5;30] !")]
        public string Name { get; set; }
        public string HeadName { get; set; }
        public DateTime CreateDate { get; set; }
        public int EmployeeAmount { get; set; }
        public string Technologies { get; set; }

        
        [Required(ErrorMessage = "Enter Project Name, please !")]
        public int ProjectId { get; set; } 
    }
}
