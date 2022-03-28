using System.ComponentModel.DataAnnotations;

namespace Onion.WebApp.ViewModels
{
    public class NewEmployeeModel
    {
        [Required(ErrorMessage = "Enter Name, please !")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Name length is [2;25] !")]
        public string FullName { get; set; }
       
        
        // Name of tech stack (frontend developer)
        [StringLength(25, MinimumLength = 2, ErrorMessage = "TechStack length is [2;25] !")]
        [Required(ErrorMessage = "Enter Technologies Stack, please !")] 
        public string TechStackName { get; set; }
        
        
        // Years Amount 
        public double Experience { get; set; }
      
        
        [Required(ErrorMessage = "Enter Position, please !")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Position length is [2;25] !")]
        public string Position { get; set; }


        // List hard skills
        [StringLength(70, MinimumLength = 0, ErrorMessage = "Technologies length is [0;70] !")]
        public string Technologies { get; set; }


        // Jun, Middle, Senior
        [Required(ErrorMessage = "Enter Level, please !")]
        [StringLength(8, MinimumLength = 5, ErrorMessage = "Level length is [5;8] !")]
        public string Level { get; set; }

        
    }
}
