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

        // public async Task<AppUser> UpdateUserAsync(string id)
        // {
        //     var usess = new AppUser();
            
        //     var user = await GetProfileAsync(id);
            
        // }

        // public async Task<AppUser> UpdatePhoneNumberAsync(string id)
        // {

        // }

        //   public async Task<AppUser> UpdatePasswordAsync(string id)
        // {

        // }
        // public async Task<AppUser> DeleteUserAsync(string id)
        // {

        // }

        //  public async Task<Address> GetAddressListAsync(string id)
        // {

        // }
        //  public async Task<Address> UpdateAddressAsync(string id)
        // {

        // }

        //  public async Task<Address> AddAddressAsync(string id)
        // {

        // }





   }
}