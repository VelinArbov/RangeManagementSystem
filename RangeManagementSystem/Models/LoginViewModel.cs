using System.ComponentModel.DataAnnotations;

namespace RangeManagementSystem.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Потребителското име е задължително.")]
        [StringLength(20, ErrorMessage = " {0} трябва да е поне {2} символа и не повече от {1} символа.", MinimumLength = 4)]
        [Display(Name = " Потребителско име:")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Паролата е задължителна.")]
        [StringLength(100, ErrorMessage = "Паролата трябва да е поне {2} символа и не повече от {1} символа.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола:")]
        public string Password { get; set; }
        public string ErrorMessage { get; set; } = "Грешен потребител и/или парола.";
    }
}
