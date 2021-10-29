using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Enums.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) => services
            .AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Enums API", Description = "An API to get all enums of your app as JSON." }))
            .AddMemoryCache()
            .AddControllers();

        public void Configure(IApplicationBuilder app) => app
            .UseDeveloperExceptionPage()
            .UseSwagger()
            .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Enums API"))
            .UseHttpsRedirection()
            .UseRouting()
            .UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
