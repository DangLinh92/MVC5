using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Redmine.Startup))]
namespace Redmine
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
