using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(dys2.Startup))]
namespace dys2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
