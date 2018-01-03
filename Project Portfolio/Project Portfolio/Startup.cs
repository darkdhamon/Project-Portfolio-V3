using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project_Portfolio.Startup))]
namespace Project_Portfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
