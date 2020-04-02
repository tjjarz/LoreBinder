using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WorldBuilder.MVC.Startup))]
namespace WorldBuilder.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
