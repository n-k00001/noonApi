using AutoMapper;
using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Domain.Models;
using noon.DTO.BasketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.Basket
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepository basketRepository,IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<bool> DeleteBasketAsync(int basketId)
        {
            return await _basketRepository.DeleteBasketAsync(basketId);


        }

        public async Task<UserBasketDto> GetBasketByUserIdAsync(string userId)
        {
            var basket = await _basketRepository.GetBasketByUserIdAsync(userId);
            return _mapper.Map<UserBasketDto>(basket);
        }

        public async Task UpdateBasketAsync(UserBasketForUpdateDto basketDto)
        {
            var basket = _mapper.Map<UserBasket>(basketDto);
            await _basketRepository.UpdateBasketAsync(basket);
        }
    }
    
}
