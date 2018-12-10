using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExaP10.Startup))]
namespace ExaP10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
