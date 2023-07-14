using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Contract
{
    public interface IUserPaymentMethodRepository
    {
        public Task<UserPaymentMethod> GetDefualt(string AppUserId);
    }
}
