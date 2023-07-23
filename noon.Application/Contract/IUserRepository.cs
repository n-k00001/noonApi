using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using noon.Application.Contract;
using noon.Domain.Contract;
using noon.Domain.Models;
using noon.Domain.Models.Identity;

namespace noon.Application.Contract
{
    public interface IUserRepository: IRepository<AppUser, string>
    {
         public  Task<AppUser> GetProfileAsync(string id);
         public Task<List<UserPaymentMethod>> GetUserPaymentsAsync(string UserId);

    }
}