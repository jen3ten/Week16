using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week16_SchoolDBPractice_04262016.Startup))]
namespace Week16_SchoolDBPractice_04262016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
