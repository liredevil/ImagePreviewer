using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ImagePreviewer.Models
{
    public class TagModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string TagTitle { get; set; }

        public virtual ICollection<ImageTagModel> TagId { get; set; }
    }
}