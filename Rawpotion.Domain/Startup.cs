using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Rawpotion.Domain.GraphQL;

namespace Rawpotion.Domain
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) => services
            .AddLogging()
            .AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:5001";

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            }).Services
            .AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                    policy
                        .WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                );
            })
            .AddAuthorization()
            .AddRawpotionGraphQL()
            .AddControllers();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) =>
            app
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseCors()
                .UseRawpotionGraphQL()
                .UseEndpoints(builder => builder.MapDefaultControllerRoute());
    }
}