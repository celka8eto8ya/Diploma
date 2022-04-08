using System.ComponentModel.DataAnnotations;

namespace Onion.AppCore.DTO
{
    public class AuthenticationDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Email, please !")]
        [EmailAddress(ErrorMessage = "Not Correct Email !")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Not Correct Email !")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Email length is [6;50] !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Password, please !")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password length is [8;50] !")]
        public string Password { get; set; }


        public int EmployeeId { get; set; }
    }
}
