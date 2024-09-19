using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<AuthorViewModel>), StatusCodes.Status200OK)]
        public async Task<List<AuthorViewModel>> GetAuthors()
        {
            try
            {

                var authors = await _authorService.GetAuthorAsync();
                return authors.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            } 
        }
        [HttpPost]
        [AllowAnonymous]
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> AddAuthor( AuthorViewModel authorViewModel)
        {
            try
            {
                var insertRes = await _authorService.AddAuthorAsync(authorViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = insertRes,
                    Message = insertRes ? Message.AUTHOR_ADD_SUCCESSFUL : Message.AUTHOR_ADD_UNSUCCESSFUL
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

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> EditAuthor( AuthorViewModel authorViewModel)
        {
            try
            {
                var editRes = await _authorService.EditAuthorAsync(authorViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = editRes,
                    Message = editRes ? Message.AUTHOR_EDIT_SUCCESSFUL : Message.AUTHOR_EDIT_UNSUCCESSFUL
                };
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        [HttpDelete("{authorId}")]
        [AllowAnonymous]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> DeleteAuthor(int authorId)
        {
            try
            {
                var deleteRes = await _authorService.RemoveAuthorAsync(authorId);

                var response = new CommonResponse
                {
                    IsSuccess = deleteRes,
                    Message = deleteRes ? Message.AUTHOR_DELETE_SUCCESSFUL : Message.AUTHOR_DELETE_UNSUCCESSFUL
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
