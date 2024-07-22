using ApertureScience.AccelerometerApi.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    /// <summary>
    /// Configures the services for the application.
    /// </summary>
    /// <param name="services">The IServiceCollection to configure.</param>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddIdentityServices(Configuration);
        services.AddApplicationServices();
        services.AddJwtAuthentication(Configuration);
        services.AddSwaggerDocumentation();
        services.AddControllers();
    }

    /// <summary>
    /// Configures the HTTP request pipeline.
    /// </summary>
    /// <param name="app">The IApplicationBuilder to configure.</param>
    /// <param name="env">The IWebHostEnvironment providing information about the hosting environment.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseSwaggerDocumentation();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        AdminUserSeeder.CreateAdminUser(app.ApplicationServices).Wait();
    }
}
