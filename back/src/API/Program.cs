using Application;
using AspNetCore.Authentication.Basic;
using Infra;
using System.Security.Claims;

namespace API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("PermissiveCORSPolicy", policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            builder.Services.AddAuthentication(BasicDefaults.AuthenticationScheme)
                .AddBasic(options =>
                {
                    options.Realm = "MyApp";
                    options.Events = new BasicEvents
                    {
                        OnValidateCredentials = context =>
                        {
                            // Validate user credentials here
                            if (context.Username == "admin" && context.Password == "password")
                            {
                                context.Principal = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, context.Username) }, context.Scheme.Name));
                                context.Success();
                            }
                            else
                            {
                                context.Fail("Invalid credentials");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.RegisterInfra(builder.Configuration);
            builder.Services.RegisterApplication();

            var app = builder.Build();
            app.UseCors("PermissiveCORSPolicy");

            using (var scope = app.Services.CreateScope())
            {
                var scopeFactory = scope.ServiceProvider.GetRequiredService<IServiceScopeFactory>();
                Infra.DependencyInjection.ApplyMigrations(scopeFactory);
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}