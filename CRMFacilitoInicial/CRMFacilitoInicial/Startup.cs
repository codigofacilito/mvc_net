using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRMFacilitoInicial.Startup))]
namespace CRMFacilitoInicial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
