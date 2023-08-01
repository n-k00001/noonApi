using noon.Domain.Contract;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Contract
{
    public interface IUserPaymentMethodRepository: IRepository<UserPaymentMethod, int>
    {
        public Task<UserPaymentMethod> GetDefualt(string AppUserId);
         public  Task<List<UserPaymentMethod>> GetUserPaymentMethods(string AppUserId);

    }
}
