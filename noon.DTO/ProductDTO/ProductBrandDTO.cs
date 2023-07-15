using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.ProductDTO
{
    public class ProductBrandDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        //LogoUrl: The URL of the brand's logo.
        public string? logoUrl { get; set; }
    }
}
