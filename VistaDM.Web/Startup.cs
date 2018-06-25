using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VistaDM.Web.Startup))]
namespace VistaDM.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
