using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImagePreviewer.Models
{
    public class ImageTagModel
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public virtual ImageModel Image { get; set; }
        public int TagId { get; set; }
        public virtual TagModel Tag { get; set; }
    }
}