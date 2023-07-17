using noon.Domain.Contract;
using noon.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Contract
{
    public interface IAddressRepository: IRepository<Address,int>
    {
    }
}
