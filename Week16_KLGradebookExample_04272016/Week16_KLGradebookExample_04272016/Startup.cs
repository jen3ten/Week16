using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week16_KLGradebookExample_04272016.Startup))]
namespace Week16_KLGradebookExample_04272016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
