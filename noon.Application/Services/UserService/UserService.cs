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
using noon.Context.Context;
using Microsoft.VisualBasic;
using Castle.Components.DictionaryAdapter.Xml;

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
            userRepository = _userRepository ;
            mapper = mapper;
            signInManager = _signInManager;
            userManager = _userManager;
        }
       

        public async Task<ProfileDTO> GetProfileById(string id)
        {
             
            var appUser = await userManager.FindByIdAsync(id);
            var Profile =  mapper.Map<ProfileDTO>(appUser);
            return Profile;

        }

     

        

        public async Task UpdateUserPassword(string email, string password, string currentPassword)
        {
            var appUser = await userManager.FindByEmailAsync(email);
            var ValidatePassword = await userManager.CheckPasswordAsync(appUser, currentPassword);

            if (ValidatePassword)
            {
                var result = await userManager.ChangePasswordAsync(appUser, currentPassword, password);
                if (!result.Succeeded)
                {
                    Console.WriteLine("Update password failed");
                }

            }
            else
            {
                Console.WriteLine("Update password successful");
            }
        }



        public async Task<ProfileDTO> UpdateUser(ProfileDTO profile)
        {

            var model = mapper.Map<AppUser>(profile);

            await userManager.UpdateAsync(model);
           
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