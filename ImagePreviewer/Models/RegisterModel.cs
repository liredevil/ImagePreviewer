using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImagePreviewer.Models
{
    public class RegisterModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z]{1,20}$", ErrorMessage = "Поле Логин должно содержать только буквы A-Z")]
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
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string RetypePassword { get; set; }
    }
}