using Microsoft.EntityFrameworkCore;
using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Models.Identity;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Infrastructure
{
    public class UserAddressRepository : Repositoy<UserAddress, int>, IUserAddressRepository
    {
        private readonly noonContext noonContext;

        public UserAddressRepository(noonContext noonContext) : base(noonContext)
        {
            this.noonContext = noonContext;
        }
        public override async Task<IQueryable<UserAddress>> GetAllAsync()
        {
            return noonContext.UserAddress.Include(x => x.Address);
        }
    }
}
