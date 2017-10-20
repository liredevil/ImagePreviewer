using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ImagePreviewer.Models
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "password - required, at least 6 characters long,at least one lowercase letter, one uppercase letter, one digit")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}