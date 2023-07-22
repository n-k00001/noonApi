using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.ProductServices;
using noon.DTO.ProductDTO;

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
        public IActionResult GetById(Guid id)
        {
            // 11111111-2222-3333-4444-555555555555
            var property = productService.GetById(id);
            return Ok(property);
        }

        //[HttpGet]
        //[Route("{items},{PageNumber}")]
        //public async Task<IActionResult> GetAll(int items, int PageNumber)
        //{
        //    var property = await productService.GetAllPropertyPagination(items, PageNumber);
        //    return Ok(property);
        //}

        [HttpGet]
        [Route("{items},{PageNumber}")]
        public IActionResult GetAll(int items, int PageNumber)
        {
            var property = productService.GetAll(items, PageNumber);
            return Ok(property);
        }


        [HttpGet]
        [Route("Search/{ProductName}")]
        public async Task<IActionResult> SearchByProductName(string ProductName)
        {
            // 11111111-2222-3333-4444-555555555555
            var property = await productService.SearchByProductName(ProductName);
            return Ok(property);
        }



    }
}
