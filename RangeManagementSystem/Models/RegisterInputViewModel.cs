using System.ComponentModel.DataAnnotations;

namespace RangeManagementSystem.Web.Models
{
    public class RegisterInputViewModel
    {
        [Required]
        //[StringLength(20, ErrorMessage = " {0} трябва да е поне {2} символа и не повече от {1} символа .", MinimumLength = 4)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        //[StringLength(100, ErrorMessage = "Паролата трябва да е поне {2} символа и не повече от {1} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        //[Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }
}
