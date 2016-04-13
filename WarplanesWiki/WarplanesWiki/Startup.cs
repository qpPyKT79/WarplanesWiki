using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WarplanesWiki.Startup))]
namespace WarplanesWiki
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
