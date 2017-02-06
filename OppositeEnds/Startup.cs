using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OppositeEnds.Startup))]
namespace OppositeEnds
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
