using System;
using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
    public class DepartmentTypeDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Name, please !")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Enter Functions, please !")]
        public string Functions { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
