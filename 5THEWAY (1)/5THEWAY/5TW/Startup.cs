using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_5TW.Startup))]
namespace _5TW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
