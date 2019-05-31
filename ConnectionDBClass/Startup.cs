using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ConnectionDBClass.Startup))]
namespace ConnectionDBClass
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
