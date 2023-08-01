using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using noon.Application.Services.ProductServices;
using noon.Application.Services.UserPaymenService;
using noon.DTO.UserPaymentDto;

namespace noon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userpaymentController : ControllerBase
    {
        private readonly IuserPaymentService _userPaymentService;

        public userpaymentController(IuserPaymentService userPaymentService)
        {
            this._userPaymentService = userPaymentService;
        }



        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var property = await _userPaymentService.GetById(id);
            return Ok(property);
        }

        [HttpPost]
        public async Task<CreateOrUpdateUserpaymentDto> create(CreateOrUpdateUserpaymentDto userpaydto)
        {
           var userpay= await _userPaymentService.Create(userpaydto);

            return userpay;


        }


        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            return Ok(_userPaymentService.Delete(Id));
        }


        [HttpGet]
     
        public async Task<IActionResult> GetAll()
        {
            var property = await _userPaymentService.GetAllPropertyPagination();
            return Ok(property);
        }


        [HttpGet("UserPaymentMethod")]
        public async Task<IActionResult> GetUserPaymentMethods(string UserId)
        {
            var paymentMethods = await _userPaymentService.GetUserPayments(UserId);
            return Ok(paymentMethods);
        }

    }
}
