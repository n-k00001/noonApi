using noon.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Models
{
    public class ProductCategory : ISoftDeleted
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imgUrl { set; get; }
        public bool isDeleted { get; set; }
        public int? parentCategoryId { get; set; }
        public virtual ProductCategory? parentCategory { get; set; }    
        // ChildrenCategories: A list of child categories id's.
        public virtual List<ProductCategory>? childrenCategories { get; set; }
        public virtual List<Product> products { get; set; }

    }
}
