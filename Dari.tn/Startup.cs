using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dari.tn.Startup))]
namespace Dari.tn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
