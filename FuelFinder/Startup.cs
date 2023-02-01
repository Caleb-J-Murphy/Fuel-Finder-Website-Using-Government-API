using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FuelFinder.Startup))]
namespace FuelFinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
