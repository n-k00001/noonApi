using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Contract
{
    public interface IBasketRepository
    {
        Task<UserBasket> GetBasketByUserIdAsync(string userId);
        Task<UserBasket> UpdateBasketAsync(UserBasket basket);
        Task<bool> DeleteBasketAsync(int basketId);

    }
}
