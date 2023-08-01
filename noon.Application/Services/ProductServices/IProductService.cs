using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.ProductServices
{
    public interface IProductService
    {
        public Task<AddEditProductDto> Create(AddEditProductDto AddEditProductDto);
        public List<ProductDto> GetAll(int Items, int PageNumber);
        public List<ProductDto> GetAllProductForAdmin();
        public List<ProductDto> GetProductForStor(string storId);
        public ProductDto GetById(Guid id);
        public AddEditProductDto GetByIdAddEdit(Guid id);
        public Task<AddEditProductDto> Update(AddEditProductDto AddEditProductDto);
        public Task<bool> Delete(Guid id);
        public Task<List<ProductDto>> SearchByProductName(string ProductName);
        public Task<List<UserReviewDTO>> GetReviewsByPrdId (Guid ProductID);
        public  Task<UserReviewDTO> CreateUserReview (UserReviewDTO reviewDTO);
        public IEnumerable<ProductDto> GetProductsByCategoryId(int categoryId);

    }
}
