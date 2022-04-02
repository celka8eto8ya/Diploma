using Onion.AppCore.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
    public class DepartmentDTO
    {
        [Required(ErrorMessage = "Enter Name, please !")]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int EmployeeAmount { get; set; }
        public IEnumerable<DepartmentType> AllDepartmentTypes { get; set; }


        public int DepartmentTypeId { get; set; } 
    }
}
