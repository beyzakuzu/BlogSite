using BlogSite.Models.Dtos.Categories.Request;
using BlogSite.Models.Dtos.Categories.Response;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abstratcts
{
    public interface ICategoryService
    {
        ReturnModel<List<CategoryResponseDto>> GetAll();
        ReturnModel<CategoryResponseDto?> GetById(int id);
        ReturnModel<CategoryResponseDto> Add(CreateCategoryRequest create);
        ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequest updateCategory);
        ReturnModel<CategoryResponseDto> Remove(int id);
    }
}
