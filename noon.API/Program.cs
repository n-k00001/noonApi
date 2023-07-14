using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using noon.Context.Context;
using noon.Domain.Models.Identity;
using Microsoft.Extensions.Configuration;
using noon.PostgreSqlContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Hangfire;
using Hangfire.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

////
/// Get Connection string and database provider from appsettings.json
////
string dbProvider = builder.Configuration.GetSection("dbProvider").Value;
string ConnectionString = builder.Configuration.GetConnectionString(dbProvider);

////
/// use dbprovider to optimize context
////
if(dbProvider == "postgresql")
{
    builder.Services.AddDbContext<noonPostgrsContext>(op =>
    {
        op.UseNpgsql(builder.Configuration.GetConnectionString("postgresql"));
    });

    ////
    /// Identity
    ////
    ///
    builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
    {
        // Default Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 0;
    }).AddEntityFrameworkStores<noonPostgrsContext>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

    ////
    /// add Hangfire
    ////

    builder.Services.AddHangfire(x => x.UsePostgreSqlStorage(ConnectionString));

}
else
{
    builder.Services.AddDbContext<noonContext>(op =>
    {
        op.UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
    });

    ////
    /// Identity
    ////

    builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
    {
        // Default Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 0;
    }).AddEntityFrameworkStores<noonContext>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
   
    ////
    /// add Hangfire
    ////

    builder.Services.AddHangfire(x => x.UseSqlServerStorage(ConnectionString));

}
////
/// start Hangfire servise
////
builder.Services.AddHangfireServer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

////
/// use dashboard path
/// 
app.UseHangfireDashboard("/dashboard");

app.MapControllers();

app.Run();
