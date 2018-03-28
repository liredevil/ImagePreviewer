using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImagePreviewer.Models
{
    public class Image
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [Remote("CheckUserName", "Image")]
        [Display(Name = "Name your media")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Add Description")]
        public string Description { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<ImageTag> ImageId { get; set; }
    }
}