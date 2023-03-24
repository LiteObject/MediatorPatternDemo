using MediatorPatternDemo.Web.Data;
using MediatorPatternDemo.Web.Library.Behavior;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;

namespace MediatorPatternDemo.Web
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            _ = builder.Host.UseSerilog((context, services, configurations) =>
            {

                _ = configurations.ReadFrom.Configuration(context.Configuration, "Serilog");
            });

            _ = builder.Services.AddControllers();
            _ = builder.Services.AddEndpointsApiExplorer();
            _ = builder.Services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Mediator Pattern Demo",
                    Version = "v1",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Name = "Mohammed Hoque",
                        Email = string.Empty
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under...",
                    }
                });
            });

            _ = builder.Services.AddMediatR(typeof(Program));
            _ = builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            _ = builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RetryPolicyBehavior<,>));

            _ = builder.Services.AddDbContext<UserContext>(
               options =>
               {
                   _ = options.EnableSensitiveDataLogging(true);
                   _ = options.UseInMemoryDatabase("MediatorPatternDemoDatabase");
               });


            WebApplication app = builder.Build();

            _ = app.UseSwagger();
            _ = app.UseSwaggerUI(options =>
            {
                options.DocumentTitle = "Mediator Pattern Demo";
            });

            _ = app.MapFallback(() => Results.Redirect("/swagger"));

            using IServiceScope serviceScope = app.Services.CreateScope();
            using UserContext context = serviceScope.ServiceProvider.GetRequiredService<UserContext>();
            _ = context?.Database.EnsureCreated();
            context?.Users.AddRange(
                new Entities.User { Id = 1, Name = "User One", Email = "test.one@email.com" },
                new Entities.User { Id = 2, Name = "User Two", Email = "test.two@email.com" }
                );
            _ = context?.SaveChanges();

            _ = app.MapControllers();

            app.Run();
        }
    }
}
