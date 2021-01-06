using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardSkills.OrchardCore.RaspberryPi.Devices;

namespace OrchardSkills.OrchardCore.RaspberryPi
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<LedDevice>();
        }

        public override void Configure(IApplicationBuilder builder, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaControllerRoute(
                name: "Relay",
                areaName: "OrchardSkills.OrchardCore.RaspberryPi",
                pattern: "Relay",
                defaults: new { controller = "Relay", action = "Index" }
            );
        }
    }
}
