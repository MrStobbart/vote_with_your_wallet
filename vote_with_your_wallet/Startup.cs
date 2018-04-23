using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(vote_with_your_wallet.Startup))]
namespace vote_with_your_wallet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
