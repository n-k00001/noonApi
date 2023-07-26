using AutoMapper;
using noon.Application.Contract;
using noon.Domain.Models;
using noon.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Application.Services.ProductCategoryServices
{
    public class ProductCategoryService:IProductCategoryService
    {
        private readonly IProductCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IProductCategoryRepository categoryRepository, IMapper mapper)
        {
           _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

       

        public async Task<ProductCategoryDTO> CreateAsync(ProductCategoryDTO catDTO)
        {
            var cat = _mapper.Map<ProductCategory>(catDTO);
            await _categoryRepository.CreateAsync(cat);
            await _categoryRepository.SaveChanges();
            return catDTO;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            return await _categoryRepository.DeleteAsync(Id);
        }

        

        public List<ProductCatogryDetailsDTO> GetAll()
        {
            var cat =_categoryRepository.GetAll();
            var model = _mapper.Map<List<ProductCatogryDetailsDTO>>(cat);
            return model;
        }

        public ProductCatogryDetailsDTO GetById(int id)
        {
            var cat = _categoryRepository.GetbyId(id);
            var model = _mapper.Map<ProductCatogryDetailsDTO>(cat);
            return model;
        }

        public async Task<IQueryable<ProductCategoryDTO>> GetAllAsync()
        {
            var cat = await _categoryRepository.GetAllAsync();
            return cat.Select(item => _mapper.Map<ProductCategoryDTO>(item)); 
        }

        

        public  async Task<ProductCategoryDTO> GetByIdAsync(int Id)
        {
            var cat = await _categoryRepository.GetByIdAsync(Id);
            var model = _mapper.Map<ProductCategoryDTO>(cat);
            return model;
        }

        public async Task<ProductCategoryDTO?> GetDetailsAsync(int id)
        {

            var cat = await _categoryRepository.GetDetailsAsync(id);
            var model = _mapper.Map<ProductCategoryDTO>(cat);
            return model;
        }

      

        public async Task<ProductCategoryDTO> UpdateAsync(ProductCategoryDTO catDTO)
        {
            if (catDTO.id == 0)
            {
                CreateAsync(catDTO);
            }
            else
            {
                var model = _mapper.Map<ProductCategory>(catDTO);
                await _categoryRepository.UpdateAsync(model);
                await _categoryRepository.SaveChanges();
            }

            return catDTO;
        }

    }
}
