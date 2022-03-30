using System.ComponentModel.DataAnnotations;

namespace Onion.WebApp.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Enter First Name !")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "First Name length is [3;50] !")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Enter Last Name !")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Last Name length is [3;50] !")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Enter Phone Number !")]
        [Phone(ErrorMessage = "Not correct Phone Number !")]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "Number length is [9;15] !")]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Enter Email !")]
        [EmailAddress(ErrorMessage = "Not Correct Email !")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Not Correct Email !")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Email length is [6;50] !")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter Password !")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password length is [8;50] !")]
        public string Password { get; set; }


        [Required(ErrorMessage = "Enter Confirm Password !")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password entered isn't correct !")]
        [StringLength(50, MinimumLength = 7, ErrorMessage = "Password length is [7;50] !")]
        public string ConfirmPassword { get; set; }

    }
}
