using noon.Domain.Contract;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Contract
{
    public interface IProductBrandRepository : IRepository<ProductBrand,int>
    {
        Task<IEnumerable<ProductBrand>> FilterByAsync(string filter, int id);
        Task<bool> DeleteBrand(int id);
        List<ProductBrand> GetAll();
    }
}
