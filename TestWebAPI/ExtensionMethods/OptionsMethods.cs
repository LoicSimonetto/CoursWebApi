using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SelfieAWookies.NET.Selfies.Infrastructures.Configurations;

namespace TestWebAPI.ExtensionMethods
{
    public static class OptionsMethods
    {
        #region Public Methods
        public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecurityOption>(configuration.GetSection("Jwt"));
        }
        #endregion
    }
}
