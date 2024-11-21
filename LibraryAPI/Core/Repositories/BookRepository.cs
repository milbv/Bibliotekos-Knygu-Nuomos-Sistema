using Serilog;
using LibraryAPI.Core.Contracts;
using LibraryAPI.Core.Models;
using Microsoft.Data.SqlClient;
using Dapper;

namespace LibraryAPI.Core.Repositories
{

    // REMOVE EBOOK/PAPERBOOK TABLES & KEEP BOOKS TABLE
    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;
        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Book> GetAll()
        {
            List<Book> result = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<Book>("SELECT * FROM Books").ToList();
            }
            return result;
        }
        public Book? GetById(int id)
        {
            Book result = new Book();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    result = connection.QueryFirst<Book>("SELECT * FROM Books WHERE Id = @bookId", new { bookId = id });
                } catch (Exception e)
                {
                    Console.WriteLine("Could not find product by id " + id);
                }
            }
            return result;
        }
        public void Add(Book book)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                if (book is ElectronicBook) {
                    connection.Execute("INSERT INTO Books (CreationDate, Name, Author, Category, RentPrice, FileFormat, FileSizeMB) VALUES (DEFAULT, @Name, @Author, @Category, @RentPrice, @FileFormat, @FileSizeMb)", book);
                } else if (book is PaperBook)
                {
                    connection.Execute("INSERT INTO Books (CreationDate, Name, Author, Category, RentPrice, NumOfCopies, ISBN) VALUES (DEFAULT, @Name, @Author, @Category, @RentPrice, @CopyAmount, @ISBN)", book);
                } else
                {
                    Console.WriteLine("Invalid book type " + book.GetType());
                }
            }
        }
        public void Remove(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("DELETE FROM Books WHERE Id = @id", new { id });
            }
        }
        public List<Book> FindBookByCategory(string category)
        {
            List<Book> result = new List<Book>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<Book>("SELECT * FROM Books WHERE Category = @category", new { category }).ToList();
            }
            return result;
        }
    }
}
