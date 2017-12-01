using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contactos3.Backend.Startup))]
namespace Contactos3.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
