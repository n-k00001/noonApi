using noon.Domain.Contract;
using noon.Domain.Models.Identity;
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
        public virtual ProductCategory? category { get; set; }
        [ForeignKey("brand")]
        public int brandId { get; set; }
        public virtual ProductBrand? brand { get; set; }
        // Image: The URL of the product's image.        
        public virtual List<Image>? images { get; set; }
        public Decimal price { get; set; }
        public bool? inStock {
            get => quantity <= 0 ? false : true;
        }
        public string? description { get; set; }
        public int quantity { set; get; }
        public bool isDeleted { get; set; } = false;
        public DateTime? createdDate { get; set; } = DateTime.Now;
        public DateTime? modifiedDate { get; set; }
        public int? size { get; set; }
        public virtual ProductSize? availableSize
        {
            get => (ProductSize?)size;
            set => size = (int?)value;
        }
        // Reviews: A list of customer reviews for the product.
        public virtual List<UserReview>? reviews { get; set; }

        [ForeignKey("store")]
        public int? storeId { set; get; }
        public virtual Store? store { get; set; }

        [ForeignKey("AppUser")]
        public string userId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
