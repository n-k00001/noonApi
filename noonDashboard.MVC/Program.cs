using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Application.Services.AdreessServices;
using noon.Application.Services.Basket;
using noon.Application.Services.OrderServices;
using noon.Application.Services.ProductBrandServices;
using noon.Application.Services.ProductCategoryServices;
using noon.Application.Services.ProductServices;
using noon.Application.Services.UserAddressServices;
using noon.Context.Context;
using noon.Domain.Contract;
using noon.Domain.Models.Identity;
using noon.Domain.Models.Order;
using noon.DTO.Helper;
using noon.Infrastructure;
using noon.Infrastructure.Repositorys;

namespace noonDashboard.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<noonContext>(op =>
            {
                op.UseSqlServer(builder.Configuration.GetConnectionString("Cs"));
            });

            builder.Services.AddAutoMapper(x => x.AddProfile(new MappingProfiles()));


            

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
            builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            builder.Services.AddScoped<IOrderItemServices, OrderItemServices>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IRepository<DeliveryMethod, int>, Repositoy<DeliveryMethod, int>>();




            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
                options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
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


            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(3);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}