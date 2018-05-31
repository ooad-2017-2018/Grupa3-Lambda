using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AmbasadadotNET.Startup))]
namespace AmbasadadotNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
