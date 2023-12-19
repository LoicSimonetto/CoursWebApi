using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SelfieAWookies.NET.Selfies.Infrastructures.Data
{
    public class SelfiesContextFactory : IDesignTimeDbContextFactory<SelfiesContext>
    {
        public SelfiesContext CreateDbContext(string[] args)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();

            configurationBuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(),"Settings","appSettings.json"));

            IConfigurationRoot configurationRoot =  configurationBuilder.Build();

            DbContextOptionsBuilder<SelfiesContext> builder = new DbContextOptionsBuilder<SelfiesContext>();
            builder.UseSqlServer(configurationRoot.GetConnectionString("SelfiesDatabase"), b => b.MigrationsAssembly("SelfieAWookies.NET.Selfies.Infrastructures"));

            SelfiesContext context = new SelfiesContext(builder.Options);

            return context;
        }
    }
}
