using MGK.ServiceBase.SeedWork;
using MGK.ServiceTemplate.API.Constants;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace MGK.ServiceTemplate.API.Infrastructure.AppRegistrations
{
    public class ConfigureCors : IAppBuilderConfiguration
    {
        public void ConfigureApp(IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseCors(CoreConstants.CorsPolicy);
        }
    }
}
