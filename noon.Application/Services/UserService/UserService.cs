using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using noon.DTO.UserDTO;
using noon.Application.Contract;
using AutoMapper;
using BCrypt.Net;
using noon.Domain.Models.Identity;

namespace noon.Application.Services.UserService
{
    public class UserService: IUserService
    {

        private IUserRepository userRepository;
         private  IMapper mapper;

        public UserService(IUserRepository _userRepository, IMapper mapper)
        {
            this.userRepository = _userRepository ;
            this.mapper = mapper;
        }
       

        public async Task<ProfileDTO> GetProfileById(string id)
        {
          ///######## OK ########
            var appUser = await userRepository.GetByIdAsync(id);
            var Profile = mapper.Map<ProfileDTO>(appUser);
            return Profile;

        }

   

        public async void UpdatePassword(string password ,string id)
       {
        var appUser = await userRepository.GetByIdAsync(id);
        appUser.PasswordHash = password;
        

       }

        public async Task<ProfileDTO> UpdateUser(string Id, ProfileDTO profile)
        {

            var obj = userRepository.GetByIdAsync(Id);

             if (obj == null) {
                Console.WriteLine("User not found id : "+Id);
            }
            else
            {
                var model = mapper.Map<AppUser>(profile);
                await userRepository.UpdateAsync(model); 
            
            }          
            return profile;

        }

         public async Task<ProfileDTO> Create(ProfileDTO profile)
        {
            var brand = mapper.Map<AppUser>(profile);
            await userRepository.CreateAsync(brand);
            return profile;
        }

        public Task<PasswordDTO> UpdateUserPassword(PasswordDTO password)
        {
            throw new NotImplementedException();
        }
    }
}