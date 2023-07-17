using noon.Domain.Models;
using noon.DTO.UserPaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.UserPaymenService
{
    public interface IuserPaymentService
    {
        public Task<CreateOrUpdateUserpaymentDto> Create(CreateOrUpdateUserpaymentDto propertyDTO);
        public Task<List<GetAllUserPaymentMethodDto>> GetAllPropertyPagination();
        public Task<GetAllUserPaymentMethodDto> GetById(int id);
        public Task<CreateOrUpdateUserpaymentDto> Update(CreateOrUpdateUserpaymentDto propertyDTO);
        public Task<bool> Delete(int id);

    }
}
