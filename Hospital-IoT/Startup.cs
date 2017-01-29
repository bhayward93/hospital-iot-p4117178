using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hospital_IoT.Startup))]
namespace Hospital_IoT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
