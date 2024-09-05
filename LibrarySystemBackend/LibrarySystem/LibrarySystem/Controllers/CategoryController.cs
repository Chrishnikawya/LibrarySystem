using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;
using Microsoft.AspNetCore.Authorization;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<CategoryViewModel>), StatusCodes.Status200OK)]
        public async Task<List<CategoryViewModel>> GetCategorys()
        {
            try
            {

                var categorys = await _categoryService.GetCategoryAsync();
                return categorys.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> AddCategory(CategoryViewModel categoryViewModel)
        {
            try
            {
                var insertRes = await _categoryService.AddCategoryAsync(categoryViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = insertRes,
                    Message = insertRes ? Message.CATEGORY_ADD_SUCCESSFUL : Message.CATEGORY_ADD_UNSUCCESSFUL
                };
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpPut]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> EditCategory( CategoryViewModel categoryViewModel)
        {
            try
            {
                var editRes = await _categoryService.EditCategoryAsync(categoryViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = editRes,
                    Message = editRes ? Message.CATEGORY_EDIT_SUCCESSFUL : Message.CATEGORY_EDIT_UNSUCCESSFUL
                };
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpDelete("{categoryId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> DeleteCategory(int categoryId)
        {
            try
            {
                var deleteRes = await _categoryService.RemoveCategoryAsync(categoryId);

                var response = new CommonResponse
                {
                    IsSuccess = deleteRes,
                    Message = deleteRes ? Message.CATEGORY_DELETE_SUCCESSFUL : Message.CATEGORY_DELETE_UNSUCCESSFUL
                };
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
