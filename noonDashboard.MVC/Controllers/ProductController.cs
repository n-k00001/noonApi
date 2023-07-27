using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.ProductBrandServices;
using noon.Application.Services.ProductCategoryServices;
using noon.Application.Services.ProductServices;
using noon.Domain.Models;
using noon.Domain.Models.Identity;
using noon.DTO.ProductDTO;
using System.Security.Claims;
using System.IO;
using noon.Context.Context;

namespace noonDashboard.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly noonContext noonContext;
        private readonly IProductService productService;
        private readonly IProductCategoryService productCategory;
        private readonly IProductBrandServices productBrand;
        private readonly UserManager<AppUser> userManager;

        public ProductController(noonContext noonContext, IProductService productService ,IProductCategoryService productCategory ,IProductBrandServices productBrand , UserManager<AppUser> userManager)
        {
            this.noonContext = noonContext;
            this.productService = productService;
            this.productCategory = productCategory;
            this.productBrand = productBrand;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var data = productService.GetAllProductForAdmin();
            return View(data);
        }


        [Authorize]
        public async Task<IActionResult> Create()
        {
            AddEditProductDto productDto = new AddEditProductDto();
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);
            productDto.userId = user.Id;
            productDto.productBrands = productBrand.GetAllBrand();
            //ViewData["Brand"] = productBrand.GetAllBrand();
            ViewData["Category"] = productCategory.GetAll();
            return View(productDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddEditProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                AddEditProductDto product = new AddEditProductDto();
                product = await productService.Create(productDto);
                if (productDto.ProductImages != null && productDto.ProductImages.Count > 0)
                {
                    foreach (IFormFile img in productDto.ProductImages)
                    {
                        string ImgPath = Directory.GetCurrentDirectory() + "/wwwroot/files/images";
                        string ImgName = Guid.NewGuid() + Path.GetFileName(img.FileName);
                        string FinalImgPath = Path.Combine(ImgPath, ImgName);

                        using (var Stream = new FileStream(FinalImgPath, FileMode.Create))
                        {
                            img.CopyTo(Stream);
                        }
                        Image image = new Image
                        {
                            ImgURL = ImgName,
                            productId = product.sku
                        };
                        noonContext.Images.Add(image);
                    }
                    noonContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return View(productDto);
        }
    }
}
