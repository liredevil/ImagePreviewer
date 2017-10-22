using System;
using System.Configuration;

namespace ImagePreviewer.CustomConfiguration
{
    public class ImageElement : ConfigurationElement
    {
        [ConfigurationProperty("directory", DefaultValue = "Arial", IsRequired = true)]
        public String Directory
        {
            get
            {
                return (String)this["directory"];
            }
            set
            {
                this["directory"] = value;
            }
        }
    }
}