using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.ProductServices;
using noon.DTO.ProductDTO;

namespace noon.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class sku : ControllerBase
    {
        private readonly IProductService productService;

        public sku(IProductService productService)
        {
         this.productService = productService;

        }
        [HttpPost]
          public async Task<IActionResult> CreateSku()
        {
       
           return Ok(GenerateRandomSKU());
        }
 
   

   
          public static Guid GenerateRandomSKU()
{
    var bytes = new byte[16];
     var rng = new Random();
    rng.NextBytes(bytes);
    bytes[6] = (byte)((bytes[6] & 0x0F) | 0x40); // set version to 4
    bytes[8] = (byte)((bytes[8] & 0x3F) | 0x80); // set variant to RFC-4122
    var sku = new Guid(bytes);

    return sku;
}

    }
}