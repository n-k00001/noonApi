using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Models;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;


namespace noon.Infrastructure.Repositorys
{
    public class ProductRep : Repositoy<Product, Guid> ,IProductRep
    {
        private readonly noonContext context;

        public ProductRep(noonContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<Product>> SearchByProductNameAsync(string ProductName)
        {
            return await context.Products
                .Where(a => a.name.ToLower().Contains(ProductName.ToLower())).Include(p => p.images).Include(b => b.brand)
                .Include(b => b.category).Include(b => b.AppUser).Include(b => b.reviews)
            .ToListAsync();
        }

        public List<Product> GetAll()
        {

            return  context.Products.Include(p => p.images).Include(b => b.brand)
                .Include(b => b.category).Include(b => b.AppUser).Include(b => b.reviews).ToList();


        }

        public Product GetById(Guid id)
        {
            return context.Products.Include(p => p.images).Include(b => b.brand)
                .Include(b => b.category).Include(b => b.AppUser).Include(b => b.reviews)
                .FirstOrDefault(p => p.sku == id);
        }

        public List<UserReview> GetReviewsByPrdId(Guid productId)
        {
            var reviews =  context.CustomerReviews.Where(r => r.ProductId == productId).ToList();
            return reviews;
        }

        public UserReview CreateUserReview(UserReview _review)
        {
            var review = new UserReview
            {
                ProductId = _review.ProductId,
                userId = _review.userId,
                Rating = _review.Rating,
                ReviewDate = DateTime.Now,
                isDeleted = false,
                Comments = _review.Comments
            };

            context.CustomerReviews.Add(review);
            context.SaveChanges();

            return review;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
          
            var result =context.Products.Where(p => p.categoryId == categoryId).ToList();
             
            return result;  
        }
    }
}
