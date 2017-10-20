using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ImagePreviewer.Models
{
    public class ImageModel  
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<ImageTagModel> ImageId { get; set; } 


    }
}