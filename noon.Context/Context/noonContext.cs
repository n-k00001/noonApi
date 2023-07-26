using Microsoft.EntityFrameworkCore;
using noon.Domain.Models.Order;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using noon.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.AspNetCore.Identity;

namespace noon.Context.Context
{
    public class noonContext : IdentityDbContext<AppUser>
    {
        public noonContext()
        {
            
        }

        public noonContext(DbContextOptions<noonContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = false;
            // ChangeTracker.CascadeDeletingTiming = CascadeTiming.OnSaveChanges;
            ChangeTracker.DeleteOrphansTiming = CascadeTiming.OnSaveChanges;
            //  ChangeTracker.ConcurrencyTokenInterceptor = new ConcurrencyTokenInterceptor();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Data Source=SQL5106.site4now.net;Initial Catalog=db_a9b12e_ecommerce;User Id=db_a9b12e_ecommerce_admin;Password=NoonEcommerce10; MultipleActiveResultSets=True;");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<UserReview> CustomerReviews { get; set; }
        public DbSet<UserBasket> userBaskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<UserAddress > UserAddress { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<UserPaymentMethod> UserPaymentMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<WishList> WishLists { get; set; }
    }
}
