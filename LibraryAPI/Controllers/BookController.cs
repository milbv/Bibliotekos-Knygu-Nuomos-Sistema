using LibraryAPI.Core.Contracts;
using LibraryAPI.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
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
        [HttpGet("GetAllBooks")]
        public List<Book> Index()
        {
            return _bookService.GetAllBooks();
        }
        [HttpGet("GetBookById")]
        public Book GetUserById(int userId)
        {
            return _bookService.GetBookById(userId);
        }
        [HttpPost("AddEBook")]
        public void AddEBook(ElectronicBook book)
        {
            _bookService.AddBook(book);
        }
        [HttpPost("AddPaperBook")]
        public void AddBook(PaperBook book)
        {
            _bookService.AddBook(book);
        }
        [HttpDelete("RemoveBook")]
        public void RemoveBook(int id)
        {
            _bookService.RemoveBook(id);
        }
        [HttpGet("FindBookByCategory")]
        public List<Book> FindBookByCategory(string category)
        {
            return _bookService.FindBookByCategory(category);
        }
    }
}
