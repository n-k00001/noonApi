using Microsoft.EntityFrameworkCore.Metadata.Internal;
using noon.Domain.Contract;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Contract
{
    public interface IProductRep : IRepository<Product, Guid>
    {

    }
}
