using AutoMapper;
using noon.Application.Contract;
using noon.Domain.Models;
using noon.DTO.ProductDTO;
using noon.DTO.UserPaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.UserPaymenService
{
    public class userPayment_Servace : IuserPaymentService

    {
        private readonly IUserPaymentMethodRepository _userPaymentMethodRepository;
        private readonly IMapper mapper;


        public userPayment_Servace(IUserPaymentMethodRepository userPaymentMethodRepository,IMapper mapper) {
            _userPaymentMethodRepository = userPaymentMethodRepository;
            this.mapper = mapper;
        }


        public async Task<GetAllUserPaymentMethodDto> GetById(int id)
        {
            var userPyment = await _userPaymentMethodRepository.GetByIdAsync(id);
            var model = mapper.Map<GetAllUserPaymentMethodDto>(userPyment);
            return model;
        }

        public  async Task<CreateOrUpdateUserpaymentDto> Create(CreateOrUpdateUserpaymentDto userDTO)
        {


            var userPayment = mapper.Map<UserPaymentMethod>(userDTO);
              await _userPaymentMethodRepository.CreateAsync(userPayment);
            await _userPaymentMethodRepository.SaveChanges();

            return userDTO;


            
        }

        public async Task<bool> Delete(int id)
        {
          return await _userPaymentMethodRepository.DeleteAsync(id);
           

        }

        public async Task<List<GetAllUserPaymentMethodDto>> GetAllPropertyPagination()
        {
           var userPay =await _userPaymentMethodRepository.GetAllAsync();
          
            var model = mapper.Map<List<GetAllUserPaymentMethodDto>>(userPay); 
            return model;

        }

      

        public async Task<CreateOrUpdateUserpaymentDto> Update(CreateOrUpdateUserpaymentDto userpaymentDto)
        {
           var model= mapper.Map<UserPaymentMethod>(userpaymentDto);
            await _userPaymentMethodRepository.UpdateAsync(model);
            return userpaymentDto;
        }
    }
}
