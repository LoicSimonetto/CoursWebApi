using MediatR;
using SelfieAWookies.NET.Selfies.Domain;
using SelfieAWookies.NET.Selfies.Infrastructures.Repositories;

namespace TestWebAPI.ExtensionMethods
{
    public static class DIMethods
    {
        #region Public methods
        /// <summary>
        /// Prepare dependencies injections
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection AddInjections(this IServiceCollection services)
        {
            services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
            //services.AddMediatR(typeof(Program).Assembly);

            return services;
        }
        #endregion
    }
}
