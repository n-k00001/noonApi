using noon.Domain.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace noon.Domain.Models
{
    public class Product : ISoftDeleted
    {
        [Key]
        public Guid sku { get; set; }
        public required string name { get; set; }
        [ForeignKey("category")]
        public int categoryId { set; get; }
        public ProductCategory? category { get; set; }
        [ForeignKey("brand")]
        public int brandId { get; set; }
        public ProductBrand? brand { get; set; }
        // Image: The URL of the product's image.        
        public List<Image>? images { get; set; }
        public Decimal price { get; set; }
        public bool? inStock {
            get => quantity <= 0 ? false : true;
        }
        public string? description { get; set; }
        public int quantity { set; get; }
        public bool isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public int? size { get; set; }
        public ProductSize? availableSize
        {
            get => (ProductSize)size;
            set => size = (int)value;
        }
        // Reviews: A list of customer reviews for the product.
        public List<UserReview>? reviews { get; set; }

        [ForeignKey("store")]
        public int? storeId { set; get; }
        public Store store { get; set; }

    }
}
