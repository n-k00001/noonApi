using noon.Application.Contract;
using noon.Domain.Contract;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Infrastructure
{
    public class UserPaymentMethodRepository : IRepository<UserPaymentMethod, int>, IUserPaymentMethodRepository
    {
        private readonly noonContext noonContext;

        public UserPaymentMethodRepository(noonContext noonContext) : base(noonContext)
        {
            this.noonContext = noonContext;
        }

        public async Task<UserPaymentMethod> GetDefualt(string AppUserId)
        {
            return noonContext.UserPaymentMethods.FirstOrDefault(p => p.UserID == AppUserId && p.IsDefault == true);
        }
    }

}
