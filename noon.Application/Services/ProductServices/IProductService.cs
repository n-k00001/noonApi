﻿using noon.DTO.ProductDTO;
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
        public Task<List<ProductDto>> GetAllPropertyPagination(int Items, int PageNumber);
        public Task<ProductDto> GetById(Guid id);
        public Task<AddEditProductDto> Update(AddEditProductDto AddEditProductDto);
        public Task<bool> Delete(Guid id);
    }
}
