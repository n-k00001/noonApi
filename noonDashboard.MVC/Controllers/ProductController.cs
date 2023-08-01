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
        [Authorize(Roles = "admin ")]
        public IActionResult Index()
        {
            var data = productService.GetAllProductForAdmin();
            return View(data);
        }

        [Authorize(Roles = "store ")]
        public async Task<IActionResult> ProductForStor()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);
            var data = productService.GetProductForStor(user.Id);
            return View(data);
        }


        [Authorize(Roles = "store ")]
        public async Task<IActionResult> Create()
        {
            AddEditProductDto productDto = new AddEditProductDto();
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);
            productDto.userId = user.Id;
            productDto.productBrands = productBrand.GetAll();
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
                return RedirectToAction("ProductForStor");
            }
            return View(productDto);
        }


        [Authorize(Roles = "admin,store")]
        public IActionResult Details(Guid id)
        {
            var data = productService.GetById(id);
            return View(data);
        }


        [Authorize(Roles = "store")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var data = productService.GetByIdAddEdit(id);
            data.productBrands = productBrand.GetAll();
            data.productCategorys = productCategory.GetAllAsync();
            var email = User.FindFirstValue(ClaimTypes.Email);
            var user = await userManager.FindByEmailAsync(email);
            data.userId = user.Id;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(AddEditProductDto productDto)
        {
            if (ModelState.IsValid)
            {

                productService.Update(productDto);
                return RedirectToAction("ProductForStor");
            }
            return View(productDto);
        }
        [Authorize(Roles = "store")]
        public IActionResult Delete(Guid id)
        {
            productService.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
