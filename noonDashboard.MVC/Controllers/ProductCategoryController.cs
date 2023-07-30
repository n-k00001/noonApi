using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.ProductBrandServices;
using noon.Application.Services.ProductCategoryServices;
using noon.Domain.Models;
using noon.DTO.ProductDTO;

namespace noonDashboard.MVC.Controllers
{
    [Authorize(Roles = "admin ")]
    public class ProductCategoryController : Controller
    {
        private readonly IProductCategoryService productCategory;

        public ProductCategoryController(IProductCategoryService productCategory)
        {
            this.productCategory = productCategory;
        }
        public  IActionResult Index()
        {
            var data =  productCategory.GetAll();
            
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            ProductCategoryDTO categoryDTO = new ProductCategoryDTO();
            categoryDTO.productCategories = (IQueryable<ProductCategoryDTO>?)await productCategory.GetAllAsync();
            return View(categoryDTO);
        }
        [HttpPost]
        public IActionResult Create(ProductCategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                productCategory.CreateAsync(categoryDTO);
                return RedirectToAction("index");
            }
            return View(categoryDTO);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await productCategory.GetByIdAsync(id);
            data.productCategories = (IQueryable<ProductCategoryDTO>?)await productCategory.GetAllAsync();
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(ProductCategoryDTO categoryDTO)
        {
            if (ModelState.IsValid)
            {
                productCategory.UpdateAsync(categoryDTO);
                return RedirectToAction("index");
            }
            return View(categoryDTO);
        }

        public IActionResult Details(int id)
        {
            var data = productCategory.GetById(id);
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            productCategory.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
