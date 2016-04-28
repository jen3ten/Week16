using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week16_KLGradeBookv2_04282016.Startup))]
namespace Week16_KLGradeBookv2_04282016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
