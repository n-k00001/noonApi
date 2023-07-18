using noon.Application.Contract;
using noon.Context.Context;
using noon.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Infrastructure
{
    public class AddressRepository : Repositoy<Address, int>, IAddressRepository
    {
        private readonly noonContext noonContext;

        public AddressRepository(noonContext noonContext) : base(noonContext)
        {
            this.noonContext = noonContext;
        }
    }
}
