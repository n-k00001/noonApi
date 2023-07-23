using noon.DTO.BasketDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.Basket
{
    public interface IBasketService
    {
        Task<UserBasketDto> GetBasketByUserIdAsync(string userId);
        Task UpdateBasketAsync(UserBasketForUpdateDto basketDto);
        Task<bool> DeleteBasketAsync(int basketId);

    }
}
