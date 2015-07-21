using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Othello.Startup))]
namespace Othello
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
