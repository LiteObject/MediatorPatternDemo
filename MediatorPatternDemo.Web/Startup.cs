using MediatorPatternDemo.Web.Library.Behaviour;
using Microsoft.OpenApi.Models;

namespace MediatorPatternDemo.Web
{
    using System;
    using System.Collections.Generic;
    using Hellang.Middleware.ProblemDetails;
    using MediatorPatternDemo.Web.Data;
    using MediatorPatternDemo.Web.Library.Behavior;
    using MediatR;
    using MediatR.Pipeline;
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
            services.AddProblemDetails(opts => {
                // Control when an exception is included
                opts.IncludeExceptionDetails = (ctx, ex) =>
                {
                    // Fetch services from HttpContext.RequestServices
                    var env = ctx.RequestServices.GetRequiredService<IHostEnvironment>();
                    return env.IsDevelopment() || env.IsStaging();
                };
            });

            /*services.AddLogging(b =>
            {
                b.AddConsole().AddFilter("*", LogLevel.Trace);
                b.AddDebug();
            }); */

            // services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(Startup));            
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RetryPolicyBehavior<,>));

            // services.AddEntityFrameworkInMemoryDatabase();
            services.AddDbContext<UserContext>(
                options =>
                    {
                        options.EnableSensitiveDataLogging(true);
                        options.UseInMemoryDatabase("MediatorPatternDemoDatabase");
                    });
            
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mediator Pattern Demo API",
                    Description = "This project demos Mediator Pattern using MediatR",
                    TermsOfService = new Uri("https://github.com/liteobject"),
                    Contact = new OpenApiContact
                    {
                        Name = "Mohammed Hoque",
                        Email = string.Empty,
                        Url = new Uri("https://github.com/liteobject"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://github.com/liteobject"),
                    }
                });
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
            app.UseProblemDetails();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();
            using UserContext context = serviceScope.ServiceProvider.GetService<UserContext>();
            context?.Database.EnsureCreated();
        }
    }
}
