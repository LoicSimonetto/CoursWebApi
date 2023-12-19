using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SelfieAWookies.NET.Selfies.Infrastructures.Configurations;

namespace TestWebAPI.ExtensionMethods
{
    public static class SecurityMethods
    {
        public const string DEFAULT_POLICY = "DEFAULT_POLICY";
        public const string DEFAULT_POLICY_2 = "DEFAULT_POLICY_2";
        public const string DEFAULT_POLICY_3 = "DEFAULT_POLICY_3";
        public static void AddCustomSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCustomCors(configuration);
            services.AddCustomAuthentication(configuration);
        }

        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            SecurityOption securityOption = new SecurityOption();
            configuration.GetSection("Jwt").Bind(securityOption);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                string maClef = securityOption.Key;
                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(maClef)),
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateActor = false,
                    ValidateLifetime = true,

                };
            });
        }

        public static void AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            CorsOption corsOption = new CorsOption();
            configuration.GetSection("Cors").Bind(corsOption);

            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
                    builder.WithOrigins(corsOption.Origin)// // AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
                options.AddPolicy(DEFAULT_POLICY_2, builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5501")// // AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
                options.AddPolicy(DEFAULT_POLICY_3, builder =>
                {
                    builder.WithOrigins("http://127.0.0.1:5502")// // AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }
    }
}
