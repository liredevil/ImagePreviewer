using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImagePreviewer.Startup))]
namespace ImagePreviewer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
