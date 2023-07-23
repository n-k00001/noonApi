using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.ProductBrandServices;
using noon.Application.Services.ProductServices;
using noon.DTO.ProductDTO;

namespace noon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IProductBrandServices brandServices;

        public ProductBrandController(IProductBrandServices brandServices)
        {
            this.brandServices = brandServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var property = await brandServices.GetAllBrand();
            Console.WriteLine(BackgroundJob.Enqueue(()=> brandServices.GetAllBrand()));
            return Ok(property);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var property = await brandServices.GetById(id);
            return Ok(property);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductBrandDTO property)
        {
            try
            {
                var brand = await brandServices.Create(property);
                return Created("", brand);
            }
            catch
            {
                return StatusCode(500, "Cant' create");
            }
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(ProductBrandDTO property)
        {
            var brand = BackgroundJob.Enqueue(()=>brandServices.Update(property)) ;
            return Ok(brand);
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            return Ok(brandServices.Delete(Id));
        }

    }
}
