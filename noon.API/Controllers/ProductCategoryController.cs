using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.OrderServices;
using noon.Application.Services.ProductBrandServices;
using noon.Application.Services.ProductCategoryServices;
using noon.DTO.ProductDTO;

namespace noon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService catServices;

        public ProductCategoryController(IProductCategoryService catServices)
        {
            this.catServices = catServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var property = await catServices.GetAllAsync();
            return Ok(property);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
            var property = await catServices.GetByIdAsync(id);
            return Ok(property);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCategoryDTO property)
        {
            try
            {
                var cat = await catServices.CreateAsync(property);
                return Created("", cat);
            }
            catch
            {
                return StatusCode(500, "Cant' create");
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(ProductCategoryDTO property)
        {
            var cat = await catServices.UpdateAsync(property);
            return Ok(cat);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            bool isDeleted = await catServices.DeleteAsync(Id);
            if (isDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
