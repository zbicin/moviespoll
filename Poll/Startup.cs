using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Poll.Startup))]
namespace Poll
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
