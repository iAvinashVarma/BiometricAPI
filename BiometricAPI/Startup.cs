using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BiometricAPI.Startup))]
namespace BiometricAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}