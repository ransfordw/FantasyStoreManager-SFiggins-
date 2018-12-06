using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FantasyStoreManager.WebMVC.Startup))]
namespace FantasyStoreManager.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
