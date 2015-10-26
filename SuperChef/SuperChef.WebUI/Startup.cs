using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperChef.Web.Startup))]
namespace SuperChef.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
