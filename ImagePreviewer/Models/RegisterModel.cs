using System.ComponentModel.DataAnnotations;

namespace ImagePreviewer.Models
{
    public class RegisterModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z]{1,20}$", ErrorMessage = "username - required, only a-z or A-Z characters")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "password - required, at least 6 characters long,at least one lowercase letter, one uppercase letter, one digit")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Return Password")]
        [Compare("Password", ErrorMessage = "The password and its confirmation do not match.")]
        public string RetypePassword { get; set; }
    }
}