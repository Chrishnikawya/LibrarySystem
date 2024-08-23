﻿using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            try
            {
                var authors = await _authorService.GetAuthorAsync();
                var author = authors.FirstOrDefault(a => a.AuthorID == id);
                if (author == null)
                {
                    return NotFound();
                }
                return Ok(author);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        [HttpPost]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> AddAuthor([FromBody] AuthorViewModel authorViewModel)
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
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> EditAuthor([FromBody] AuthorViewModel authorViewModel)
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

        [HttpDelete("{id}")]
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
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
