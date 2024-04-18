using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JewelryShop.Startup))]
namespace JewelryShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
