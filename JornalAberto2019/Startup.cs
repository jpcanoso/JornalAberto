using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JornalAberto2019.Startup))]
namespace JornalAberto2019
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
