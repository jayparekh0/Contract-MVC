using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Contract.Startup))]
namespace Contract
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
