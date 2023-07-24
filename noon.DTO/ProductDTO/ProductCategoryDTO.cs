using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.ProductDTO
{
    public class ProductCategoryDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        public string? imgUrl { set; get; }
        public int? parentCategoryId { get; set; }
        public IQueryable<ProductCategoryDTO>? productCategories { get; set; }

    }
}
