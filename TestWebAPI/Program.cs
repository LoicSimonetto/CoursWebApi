using SelfieAWookies.NET.Selfies.Infrastructures.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using SelfieAWookies.NET.Selfies.Domain;
using SelfieAWookies.NET.Selfies.Infrastructures.Repositories;
using TestWebAPI.ExtensionMethods;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using SelfieAWookies.NET.Selfies.Infrastructures.Loggers;
using TestWebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SelfiesContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SelfiesDatabase"),  sqlOptions =>
    {
        
    });
});
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
}).AddEntityFrameworkStores<SelfiesContext>();

//builder.Services.AddScoped<ISelfieRepository, DefaultSelfieRepository>();
builder.Services.AddCustomOptions(builder.Configuration);
builder.Services.AddInjections()
                .AddCustomSecurity(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "TestWebApi", Version = "v1" });
});

builder.Logging.AddProvider(new CustomLoggerProvider());

var app = builder.Build();

app.UseMiddleware<LogRequestMiddleware>();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TestWebApi v1"));

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(SecurityMethods.DEFAULT_POLICY);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
