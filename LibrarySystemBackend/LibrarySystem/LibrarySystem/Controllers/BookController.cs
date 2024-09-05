using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using LibrarySystem.ViewModels;
using LibrarySystem.Response;
using LibrarySystem.Services;
using Microsoft.AspNetCore.Authorization;

namespace LibrarySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<AuthorViewModel>), StatusCodes.Status200OK)]
        public async Task<List<BookViewModel>> GetBooks()
        {
            try
            {
                var books = await _bookService.GetBookAsync();
                return books.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            try
            {
                var books = await _bookService.GetBookAsync();
                var book = books.FirstOrDefault(a => a.BookID == id);
                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> AddBook( BookViewModel bookViewModel)
        {
            try
            {
                var insertRes = await _bookService.AddBookAsync(bookViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = insertRes,
                    Message = insertRes ? Message.BOOK_ADD_SUCCESSFUL : Message.BOOK_ADD_UNSUCCESSFUL
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
        public async Task<CommonResponse> EditBook( BookViewModel bookViewModel)
        {
            try
            {
                var editRes = await _bookService.EditBookAsync(bookViewModel);

                var response = new CommonResponse
                {
                    IsSuccess = editRes,
                    Message = editRes ? Message.BOOK_EDIT_SUCCESSFUL : Message.BOOK_EDIT_UNSUCCESSFUL
                };
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpDelete("{bookId}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(CommonResponse), StatusCodes.Status200OK)]
        public async Task<CommonResponse> DeleteBook(int bookId)
        {
            try
            {
                var deleteRes = await _bookService.RemoveBookAsync(bookId);

                var response = new CommonResponse
                {
                    IsSuccess = deleteRes,
                    Message = deleteRes ? Message.BOOK_DELETE_SUCCESSFUL : Message.BOOK_DELETE_UNSUCCESSFUL
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


