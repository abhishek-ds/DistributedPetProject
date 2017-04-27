using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DistributedPetProject.Startup))]
namespace DistributedPetProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
