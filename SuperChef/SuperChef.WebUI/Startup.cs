using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperChef.WebUI.Startup))]
namespace SuperChef.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
