//using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Repository;
using Service.Service.Contract;
using Service.Service.Implementation;
//using Microsoft.FeatureManagement;
//using OA.Infrastructure.Extension;
//using OA.Persistence;
//using OA.Service;
//using Serilog;
using System;
using System.IO;
using System.Reflection;

namespace FCI
{
    public class Startup
    {
        private readonly IConfigurationRoot configRoot;
        public Startup(IConfiguration configuration)
        {
            //Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            Configuration = configuration;

            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            configRoot = builder.Build();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(con => con.UseSqlServer(Configuration.GetConnectionString("SQLConnection")));
            services.AddScoped<IUser, UserService>();
            services.AddScoped<ISupplier, SupplierService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI_Layer", Version = "v1" });
            });
            //services.AddController();

            //services.AddDbContext(Configuration, configRoot);

            //services.AddIdentityService(Configuration);

            //services.AddAutoMapper();

            //services.AddScopedServices();

            //services.AddTransientServices();

            // services.AddSwaggerOpenAPI();

            //services.AddMailSetting(Configuration);

            //services.AddServiceLayer();

            //services.AddVersion();


            //services.AddDbContext()
            //    .AddDbContextCheck<ApplicationDbContext>(name: "Application DB Context", failureStatus: HealthStatus.Degraded)
            //    .AddUrlGroup(new Uri("https://amitpnk.github.io/"), name: "My personal website", failureStatus: HealthStatus.Degraded)
            //    .AddSqlServer(Configuration.GetConnectionString("FCIConn"));

            //services.AddHealthChecksUI(setupSettings: setup =>
            //{
            //    setup.AddHealthCheckEndpoint("Basic Health Check", $"/healthz");
            //});

            //services.AddFeatureManagement();
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory log)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                app.UseSwaggerUI(setupAction =>
                {
                    setupAction.SwaggerEndpoint("/swagger/v1/swagger.json", "Onion Architecture API");
                    setupAction.RoutePrefix = "OpenAPI";
                });
                // app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI_Layer v1"));
            }

            //app.UseCors(options =>
            //     options.WithOrigins("http://localhost:3000", "http://localhost:44356")
            //     .AllowAnyHeader()
            //     .AllowAnyMethod());

            // app.ConfigureCustomExceptionMiddleware();

            // log.AddSerilog();

            //app.ConfigureHealthCheck();


            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            // app.ConfigureSwagger();
            //app.UseHealthChecks("/healthz", new HealthCheckOptions
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
            //    ResultStatusCodes =
            //    {
            //        [HealthStatus.Healthy] = StatusCodes.Status200OK,
            //        [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
            //        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
            //    },
            //}).UseHealthChecksUI(setup =>
            //{
            //    setup.ApiPath = "/healthcheck";
            //    setup.UIPath = "/healthcheck-ui";
            //    //setup.AddCustomStylesheet("Customization/custom.css");
            //});


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
