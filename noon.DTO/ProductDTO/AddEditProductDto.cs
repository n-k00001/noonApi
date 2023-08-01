using Microsoft.AspNetCore.Http;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.DTO.ProductDTO
{
    public class AddEditProductDto
    {
        public Guid sku { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [MinLength(1, ErrorMessage = "Min Lin 1")]
        [StringLength(150, ErrorMessage = "Max Len 150")]
        public string name { get; set; }
        [Required(ErrorMessage = "Choose Category")]
        public int categoryId { set; get; }
        //public ProductCategory? category { get; set; }
        [Required(ErrorMessage = "Choose Brand")]
        public int brandId { get; set; }
        public List<ProductBrandDTO>? productBrands { get; set; }
        public Task<IQueryable<ProductCategoryDTO>>? productCategorys { get; set; }
        //public ProductBrand? brand { get; set; }
        // Image: The URL of the product's image.        
        //public List<string>? images { get; set; }
        [Required(ErrorMessage = "Price Required")]
        public Decimal price { get; set; }
        public bool? inStock
        {
            get => quantity <= 0 ? false : true;
        }
        [Required(ErrorMessage = "Description Required")]
        public string? description { get; set; }
        [Required(ErrorMessage = "Quantity Required")]
        public int quantity { set; get; }
        public bool isDeleted { get; set; } = false;
        public DateTime? createdDate { get; set; } = DateTime.Now;
        public DateTime? modifiedDate { get; set; }
        public int? size { get; set; }
        public ProductSize? availableSize
        {
            get => (ProductSize?)size;
            set => size = (int?)value;
        }
        // Reviews: A list of customer reviews for the product.
        //public List<UserReview>? reviews { get; set; }
        public int? storeId { set; get; }
        //public Store? store { get; set; }
        public string userId { get; set; }

        public string? ImgURL { get; set; }
        [Required(ErrorMessage = "Image Required")]
        public List<IFormFile>? ProductImages { get; set; }
    }
}
