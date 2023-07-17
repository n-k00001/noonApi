using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using noon.DTO.UserDTO;
using noon.Application.Contract;
using AutoMapper;
using BCrypt.Net;

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
        public Task<ProfileDTO> Create(ProfileDTO propertyDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(string id)
        {
            throw new NotImplementedException();
        }

      

        public async Task<ProfileDTO> GetById(string id)
        {
          
            var appUser = await userRepository.GetByIdAsync(id);
            var Profile = mapper.Map<ProfileDTO>(appUser);
            return Profile;

        }

        public async void UpdatePasswordAsync(string password ,string id)
       {
        var appUser = await userRepository.GetByIdAsync(id);
        appUser.PasswordHash = password;
        

       }

        // public Task<ProfileDTO> GetProfile(string id)
        // {

        // }

        public Task<ProfileDTO> Update(ProfileDTO propertyDTO)
        {
            throw new NotImplementedException();
        }
    }
}