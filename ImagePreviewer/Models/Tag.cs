using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImagePreviewer.Models
{
    public class Tag
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string TagTitle { get; set; }

        public virtual ICollection<ImageTag> TagId { get; set; }
    }
}