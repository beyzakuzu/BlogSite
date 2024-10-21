using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Categories.Request;
using BlogSite.Models.Dtos.Categories.Response;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstratcts;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest create)
        {
            Category createdCategory = _mapper.Map<Category>(create);
            createdCategory.Id = new Random().Next(1, 1000); // Örnek bir Id atama işlemi

            _categoryRepository.Add(createdCategory);

            CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(createdCategory);

            return new ReturnModel<CategoryResponseDto>
            {
                Data = response,
                Message = "Kategori Eklendi.",
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<List<CategoryResponseDto>> GetAll()
        {
            List<Category> categories = _categoryRepository.GetAll();
            List<CategoryResponseDto> responses = _mapper.Map<List<CategoryResponseDto>>(categories);

            return new ReturnModel<List<CategoryResponseDto>>
            {
                Data = responses,
                Message = string.Empty,
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<CategoryResponseDto?> GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            var response = _mapper.Map<CategoryResponseDto>(category);

            return new ReturnModel<CategoryResponseDto?>
            {
                Data = response,
                Message = string.Empty,
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<CategoryResponseDto> Remove(int id)
        {
            Category category = _categoryRepository.GetById(id);
            Category deletedCategory = _categoryRepository.Remove(category);

            CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(deletedCategory);

            return new ReturnModel<CategoryResponseDto>
            {
                Data = response,
                Message = "Kategori Silindi.",
                StatusCode = 200,
                Success = true
            };
        }

        public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategory)
        {
            Category category = _categoryRepository.GetById(updateCategory.Id);

            category.Name = updateCategory.Name;

            Category updatedCategory = _categoryRepository.Update(category);

            CategoryResponseDto dto = _mapper.Map<CategoryResponseDto>(updatedCategory);

            return new ReturnModel<CategoryResponseDto>
            {
                Data = dto,
                Message = "Kategori Güncellendi",
                StatusCode = 200,
                Success = true
            };
        }
    }

}
