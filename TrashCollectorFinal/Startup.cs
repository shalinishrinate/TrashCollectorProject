using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TrashCollectorFinal.Startup))]
namespace TrashCollectorFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
