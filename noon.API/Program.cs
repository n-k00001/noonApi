using Microsoft.AspNetCore.Hosting;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Application.Services.ProductBrandServices;
using noon.Application.Services.ProductServices;
using noon.Application.Services.UserPaymenService;
using noon.Context.Context;
using noon.Domain.Models;
using noon.Domain.Models.Identity;
using noon.DTO.Helper;
using noon.Infrastructure;
using noon.Infrastructure.Repositorys;
using AutoMapper;
using noon.Application.Services.ProductCategoryServices;
using noon.Application.Services.UserAddressServices;
using noon.Application.Services.AdreessServices;
using noon.Application.Services.Basket;
using noon.Application.Services.Mailing_SMS_Service;
using noon.Infrastructure.User;
using noon.Application.Services.UserService;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Proxies;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRep, ProductRep>();

    
// json
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});


builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfiles()));

builder.Services.AddDbContext<noonContext>(op =>
{
    //  op.UseLazyLoadingProxies()
    //  .UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
 op.UseLazyLoadingProxies()
        .UseNpgsql(builder.Configuration.GetConnectionString("postgresql"));
});
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

builder.Services.AddScoped<IuserPaymentService, userPayment_Servace>();
builder.Services.AddScoped<IUserPaymentMethodRepository,UserPaymentMethodRepository>();





// builder.Services.AddScoped<IPasswordHasher<IdentityUser>, BCryptPasswordHasher<IdentityUser>>();
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
/// Get Connection string and database provider from appsettings.json
////
string dbProvider = builder.Configuration.GetSection("dbProvider").Value;
string ConnectionString = builder.Configuration.GetConnectionString(dbProvider);


//// JWT
builder.Services.AddScoped(typeof(ITokenService), typeof(TokenService));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options=>
    {

        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience =true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
            ValidateLifetime =true

        };

    });

////
/// add Hangfire
////
builder.Services.AddHangfire(x => x.UsePostgreSqlStorage(ConnectionString));////
/// start Hangfire servise
////
builder.Services.AddHangfireServer();

// Mail settings configuration 
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();


builder.Services.AddScoped<IuserPaymentService, userPayment_Servace>();
builder.Services.AddScoped<IUserPaymentMethodRepository,UserPaymentMethodRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRep, ProductRep>();
builder.Services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
builder.Services.AddScoped<IProductBrandServices, ProductBrandServices>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IUserAddressRepository, UserAddressRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IUserAddressServices, UserAddressServices>();
builder.Services.AddScoped<IAddressServices, AddressServices>();
builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();


builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBasketService, BasketService>();    

builder.Services.AddScoped(typeof(ITokenService), typeof(TokenService));
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

