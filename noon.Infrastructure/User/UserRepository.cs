using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using noon.DTO.UserDTO;
using noon.Context.Context;
using noon.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using BCryptNet = BCrypt.Net.BCrypt;
using noon.Domain.Models;

namespace noon.Infrastructure.User
{
    public class UserRepository:Repositoy<AppUser, string>, IUserRepository
    {
        private readonly noonContext Context;

       
        public UserRepository(noonContext noonContext):base(noonContext)
        {
            this.Context = noonContext;
        }

     
 // public async Task<bool> UpdateUserPassword(string password, AppUser appUser)
        // {
        //     appUser.PasswordHash = BCryptNet.HashPassword(password);
 
        // }



        //   public async Task<UserRepository> UpdateAsync(UserRepository TEntity)
        // {
        //     var entity = (Context.Update(TEntity)).Entity;
        //     await SaveChanges();
        //     return entity;
        // }

        
      
         public async Task<AppUser> GetProfileAsync(string id)

        {    
            
             return await Context.Users.Where(c=> c.Id == id).FirstOrDefaultAsync();
        }


    

        public async Task<List<UserPaymentMethod>> GetUserPaymentsAsync(string UserId)
        {

            return await Context.UserPaymentMethods.Where(c=> c.UserID == UserId).ToListAsync();

        }





   }
}