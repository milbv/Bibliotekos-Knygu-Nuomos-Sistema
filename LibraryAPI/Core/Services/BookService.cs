using LibraryAPI.Core.Contracts;
using LibraryAPI.Core.Models;
using LibraryAPI.Core.Repositories;
using Serilog;

namespace LibraryAPI.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }
        public Book? GetBookById(int id)
        { 
            return _bookRepository.GetById(id);
        }
        public void AddBook(Book book)
        {
            _bookRepository.Add(book);
            Log.Information("Book logged: " + book);
        }
        public void RemoveBook(int id)
        {
            _bookRepository.Remove(id);
        }
        public List<Book> FindBookByCategory(string category)
        {
            return _bookRepository.FindBookByCategory(category);
        }
    }
}
