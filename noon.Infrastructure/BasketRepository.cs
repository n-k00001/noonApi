using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Infrastructure
{
    public class BasketRepository : IBasketRepository
    {
        private readonly noonContext _noonContext;

        public BasketRepository(noonContext noonContext)
        {
            _noonContext = noonContext;
        }

        public async Task<bool> DeleteBasketAsync(int basketId)
        {
            var basket = await _noonContext.userBaskets.FindAsync(basketId);
            if (basket == null)
            {
                return false; 
            }

            _noonContext.userBaskets.Remove(basket);
            await _noonContext.SaveChangesAsync();

            return true;
        }

        public async Task<UserBasket> GetBasketByUserIdAsync(string UserId)
        {
            return await _noonContext.userBaskets
                       .Include(basket => basket.Items)
                        .FirstOrDefaultAsync(basket => basket.userId == UserId);
        }

        public async Task<UserBasket> UpdateBasketAsync(UserBasket basket)
        {
            _noonContext.userBaskets.Update(basket);
            await _noonContext.SaveChangesAsync();
            return basket;
        }
    }
}
