namespace MediatorPatternDemo.Web
{
    using System;
    using System.Collections.Generic;
    using MediatorPatternDemo.Web.Data;

    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// The configure services.
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddLogging(b =>
                {
                    b.AddConsole().AddFilter("*", LogLevel.Trace);
                    b.AddDebug();
                });

            services.AddMediatR(typeof(Startup));

            // services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<UserContext>(
                options =>
                    {
                        options.EnableSensitiveDataLogging(true);
                        options.UseInMemoryDatabase("MediatorPatternDemoDatabase");
                    });
        }

        /// <summary>
        /// The configure.
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        /// <param name="env">
        /// The env.
        /// </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
            {
                using (UserContext context = serviceScope.ServiceProvider.GetService<UserContext>())
                {
                    context.Database.EnsureCreated();
                }
            }
        }
    }
}
