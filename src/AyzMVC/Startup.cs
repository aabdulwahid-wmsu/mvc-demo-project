using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AyzMVC.Startup))]
namespace AyzMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
