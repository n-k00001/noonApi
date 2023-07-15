using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.ProductServices;

namespace noon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            // 11111111-2222-3333-4444-555555555555
            var property = await productService.GetById(id);
            return Ok(property);
        }

        [HttpGet]
        [Route("{items},{PageNumber}")]
        public async Task<IActionResult> GetAll(int items, int PageNumber)
        {
            var property = await productService.GetAllPropertyPagination(items, PageNumber);
            return Ok(property);
        }

    }
}
