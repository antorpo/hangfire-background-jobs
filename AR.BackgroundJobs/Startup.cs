using AR.BackgroundJobs.Configuration;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace AR.BackgroundJobs
{
    public class Startup
    {
        private readonly ILogger<Startup> _logger;

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
           _logger = logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string hangFireConn = Configuration.GetConnectionString("HangfireConnection");
            services.AddServices(hangFireConn);
           
            #region Startup Log
            _logger.LogInformation("============ STARTUP ================");
            _logger.LogInformation($"Hangfire Connection: {hangFireConn}");
            _logger.LogInformation($"Date = {DateTime.UtcNow.ToLocalTime()}");
            _logger.LogInformation("============ END STARTUP ============");
            #endregion Startup Log
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHangfireDashboard();
            app.ApplicationServices.AddJobs(Configuration);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
        }
    }
}
