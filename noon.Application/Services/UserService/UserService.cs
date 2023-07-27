using System.Reflection;
using System.Reflection.Metadata;
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
using noon.DTO.UserPaymentDto;

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
       

        public async Task<ProfileDTO> GetProfileByEmail(string email)
        {
             
            var appUser = await userManager.FindByEmailAsync(email);
            // var Profile =  mapper.Map<ProfileDTO>(appUser);
            var Profile = new ProfileDTO()
            {
            DisplayName = appUser.DisplayName,
            Email = appUser.Email,
            EmailConfirmed = appUser.EmailConfirmed,
            Id = appUser.Id,
            PhoneNumber = appUser.PhoneNumber,
            PhoneNumberConfirmed=appUser.PhoneNumberConfirmed,
            UserName= appUser.UserName
            };
            
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



        public async Task<ProfileDTO> UpdateUser(ProfileDTO profile, AppUser appUser)
        {

             //var model =  mapper.Map<AppUser>(profile);
           // var model = new AppUser()
            // {
            // DisplayName = profile.DisplayName,
            // Email = profile.Email,
            // EmailConfirmed = profile.EmailConfirmed,
            // Id = profile.Id,
            // PhoneNumber = profile.PhoneNumber,
            // PhoneNumberConfirmed=profile.PhoneNumberConfirmed,
            // UserName= profile.UserName
            // };
            appUser.DisplayName =profile.DisplayName;
            appUser.Email = profile.Email;
            appUser.UserName = profile.UserName;
            appUser.PhoneNumberConfirmed = profile.PhoneNumberConfirmed;
            appUser.EmailConfirmed = profile.EmailConfirmed;

            await userManager.UpdateAsync(appUser);
           
            return profile;
        }
        public async Task<ProfileDTO> Create(ProfileDTO profile)
        {
            var brand = mapper.Map<AppUser>(profile);
            await userRepository.CreateAsync(brand);
            return profile;
        }

        public async Task<List<GetAllUserPaymentMethodDto>> getPaymentsAsync(string userId)
        {
            var PaymentMethods = await userRepository.GetUserPaymentsAsync(userId);
           // var PaymentMethodsList =  mapper.Map<List<GetAllUserPaymentMethodDto>>(PaymentMethods);

        var PaymentMethodsList = new List<GetAllUserPaymentMethodDto>();
        foreach(var _method in PaymentMethods)
        {
             var Method = new GetAllUserPaymentMethodDto()
             {
               CardNumber = _method.CardNumber,
               CVV=_method.CVV,
               ExpirationDate=_method.ExpirationDate,
               IsDefault= _method.IsDefault,
               PaymentMethodID= _method.PaymentMethodID,
               Provider= _method.Provider
             };
             PaymentMethodsList.Add(Method);

        }
            return  PaymentMethodsList;
        }

     
    }
}