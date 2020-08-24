using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetSignalR.App.Startup))]
namespace AspNetSignalR.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();

            ConfigureAuth(app);
        }
    }
}
