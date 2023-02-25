using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

using QuesFight.Providers;
using QuesFight.Repositories;
using QuesFight.Repositories.QuestionRepositories;

namespace QuesFight.Services
{
    public class AppStart
    {
        public static void ConfigJwt(IConfiguration config, IServiceCollection services) {
            JwtOptions jwtOptions = new();
            config.GetSection("Jwt").Bind(jwtOptions);
            services.Configure<JwtOptions>(options =>
            {
                options.Issuer = jwtOptions.Issuer;
                options.Audience = jwtOptions.Audience;
                options.Secret = jwtOptions.Secret;
                options.LifetimeInMinutes = jwtOptions.LifetimeInMinutes;
            });
            services.AddTransient<JwtProvider>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidAudience = jwtOptions.Audience,
                        ValidIssuer = jwtOptions.Issuer,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["Bearer"];
                            return Task.CompletedTask;
                        }
                    };
                })
                .AddCookie(options =>
                {
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Cookie.IsEssential = true;
                });
        }

        public static void ConfigRepositories(IServiceCollection services) {
            services.AddScoped<UserRepo>();
            services.AddScoped<LearningRepo>();
            services.AddScoped<QuestionRepo>();
        }
    }
}
