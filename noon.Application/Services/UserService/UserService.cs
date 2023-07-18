using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using noon.DTO.UserDTO;
using noon.Application.Contract;
using AutoMapper;
using noon.Domain.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace noon.Application.Services.UserService
{
    public class UserService: IUserService
    {

        private IUserRepository userRepository;
         private  IMapper mapper;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        public UserService(IUserRepository _userRepository, IMapper mapper, UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            this.userRepository = _userRepository ;
            this.mapper = mapper;
            signInManager = _signInManager;
            userManager = _userManager;
        }
       

        public async Task<ProfileDTO> GetProfileById(string id)
        {
       
            var appUser = await userRepository.GetByIdAsync(id);
            var Profile = mapper.Map<ProfileDTO>(appUser);
            return Profile;

        }

   
        public async Task<PasswordDTO> GetPasswordById(string id)
        {
          var appUser = await userRepository.GetByIdAsync(id);
          var Password = mapper.Map<PasswordDTO>(appUser);
          Console.WriteLine("get password");
          return Password;
        }
        public async Task<bool> ValidatePassword(string id,string password_UN_Hashed)  
        {
            var Password = await GetPasswordById(id);
            Password.Password_UN_Hashed = password_UN_Hashed;
           var user = await userManager.FindByIdAsync(id);
            var result = await signInManager.CheckPasswordSignInAsync(user, password_UN_Hashed, false);
            // bool isMatched = BCrypt.Net.BCrypt.Verify(password_UN_Hashed, Password.PasswordHash);
            
            Console.WriteLine("Password hash is {0}",Password.PasswordHash);
            Console.WriteLine("Password Un hash is {0}",password_UN_Hashed);
            if(!result.Succeeded) 
            {
              Console.WriteLine("Password validation succeeded");

                return false;
                
            }
            else
            {
                Console.WriteLine("Password validation succeeded");
                return true;
            }
            
        } 
        
// public async Task<bool> ValidatePassword(string id, string password)
// {
//     var appUser = await userRepository.GetByIdAsync(id);
//     bool isMatched = BCryptNet.Verify(password, appUser.PasswordHash);
//     Console.WriteLine("Password hash is {0}", appUser.PasswordHash);
//     Console.WriteLine("Password Un hash is {0}", password);
//     return isMatched;
// }
        public async void UpdateUserPassword(string email, string password ,string currentPassword)
       {

         //var appUser = await userRepository.GetByIdAsync(id);
        // var appUser =  await userManager.FindByIdAsync(id);
        var appUser = await userManager.FindByEmailAsync(email);
var result = await userManager.ChangePasswordAsync(appUser, currentPassword, password);
if (!result.Succeeded)
{
        Console.WriteLine("Update password successful");
  }
    }
    
// public async void UpdateUserPassword(string password, string id)
// {
//     var appUser = await userRepository.GetByIdAsync(id);
//     appUser.PasswordHash = BCryptNet.HashPassword(password, workFactor: 12);
//     await userRepository.UpdateAsync(appUser);
// }


        public async Task<ProfileDTO> UpdateUser(ProfileDTO profile)
        {

       
               var model = mapper.Map<AppUser>(profile);
            await userRepository.UpdateAsync(model);
            return profile;

        }

         public async Task<ProfileDTO> Create(ProfileDTO profile)
        {
            var brand = mapper.Map<AppUser>(profile);
            await userRepository.CreateAsync(brand);
            return profile;
        }


      
    }
}