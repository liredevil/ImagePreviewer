using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImagePreviewer.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "EmailAddress")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "EmailAddress")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The value {0} must contain at least {2} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Return Password")]
        [Compare("Password", ErrorMessage = "The password and its confirmation do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
