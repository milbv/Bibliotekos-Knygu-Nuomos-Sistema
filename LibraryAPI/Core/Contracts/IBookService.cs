using LibraryAPI.Core.Models;

namespace LibraryAPI.Core.Contracts
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book? GetBookById(int id);
        void AddBook(Book book);
        void RemoveBook(int id);
        List<Book> FindBookByCategory(string category);
    }
}
