using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.ProductDTO
{
    public class ProductCatogryDetailsDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        public string? imgUrl { set; get; }
        public int? parentCategoryId { get; set; }
        public string parentCategory { get; set; }
    }
}
