using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tattoor.Startup))]
namespace Tattoor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
