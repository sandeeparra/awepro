using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ISW_Dashboard.Startup))]
namespace ISW_Dashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
