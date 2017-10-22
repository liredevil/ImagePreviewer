using System.Configuration;

namespace ImagePreviewer.CustomConfiguration
{
    public class ImageSection : ConfigurationSection
    {
        [ConfigurationProperty("image")]
        public ImageElement Image
        {
            get
            {
                return (ImageElement)this["image"];
            }

            set
            {
                this["image"] = value;
            }

        }
    }
}