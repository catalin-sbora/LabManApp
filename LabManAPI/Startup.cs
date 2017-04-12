using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DomainModel.Interfaces;
using DomainModel.EntityFramework;
using DomainServices.Interfaces;
using DomainServices.DefaultImplementation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace LabManAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
           /* services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder.AllowAnyOrigin());
            });*/
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddScoped<IPersistenceContext>(provider => { return new EFPersistenceContext(Configuration); });
            services.AddScoped<ILabManDataAggregationService>(provider => { return new LabManDataAggregationService(services.First(s => s.ServiceType.Equals(typeof(IPersistenceContext))).ImplementationInstance as IPersistenceContext); });
            services.AddMvc();
            
            /*.AddJsonOptions(options => {                
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });*/
        }
        private static void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                context.Response.StatusCode = 200;               
                await context.Response.Body.FlushAsync();
                //context.Response.OnCompleted((object, Task) => { return null; });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.MapWhen(context => context.Request.Method.Equals("OPTIONS"), HandleBranch);
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseApplicationInsightsRequestTelemetry();

            // app.UseApplicationInsightsExceptionTelemetry();
           // app.UseCors("AllowAnyOrigin");

            app.UseMvc();
        }
    }
}
