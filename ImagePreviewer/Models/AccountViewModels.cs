using System.ComponentModel.DataAnnotations;

namespace ImagePreviewer.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "EmailAddress")]
        [EmailAddress(ErrorMessage = "The EmailAddress field does not contain a valid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Required field")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z]{1,20}$", ErrorMessage = "username - required, only a-z or A-Z characters")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [EmailAddress(ErrorMessage = "The EmailAddress field does not contain a valid email address.")]
        [Display(Name = "EmailAddress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(100, ErrorMessage = "The value {0} must contain at least {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=^.{6,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "password - required, at least 6 characters long,at least one lowercase letter, one uppercase letter, one digit,one special character")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Return Password")]
        [Compare("Password", ErrorMessage = "The password and its confirmation do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
