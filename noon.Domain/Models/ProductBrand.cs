﻿using noon.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models
{
    public class ProductBrand : ISoftDeleted
    {
        public int id { get; set; }
        public  string name { get; set; }

        //LogoUrl: The URL of the brand's logo.
        public string? logoUrl { get; set; }
        public bool isDeleted { get; set; } = false;
        public List<Product>? products { get; set; }
    }
}
