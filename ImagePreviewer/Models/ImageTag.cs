using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImagePreviewer.Models
{
    public class ImageTag
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}