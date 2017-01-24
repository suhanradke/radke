using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SLUEbay.Startup))]
namespace SLUEbay
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
