using LibraryAPI.Core.Models;

namespace LibraryAPI.Core.Contracts
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book? GetById(int id);
        void Add(Book book);
        void Remove(int id);
        List<Book> FindBookByCategory(string category);
    }
}
