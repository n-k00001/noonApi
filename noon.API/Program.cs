using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Application.Services.ProductBrandServices;
using noon.Application.Services.ProductServices;
using noon.Context.Context;
using noon.Domain.Models;
using noon.Domain.Models.Identity;
using noon.DTO.Helper;
using noon.Infrastructure;
using noon.Infrastructure.Repositorys;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<noonContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
    //op.UseNpgsql(builder.Configuration.GetConnectionString("Cs"));
});
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


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRep, ProductRep>();
builder.Services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
builder.Services.AddScoped<IProductBrandServices, ProductBrandServices>();



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
//app.UseHangfireDashboard("/dashboard");

app.MapControllers();

app.Run();
