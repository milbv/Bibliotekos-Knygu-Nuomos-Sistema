using Dapper;
using LibraryAPI.Core.Contracts;
using LibraryAPI.Core.Models;
using Microsoft.Data.SqlClient;

namespace LibraryAPI.Core.Repositories
{
    public class RentRepository : IRentRepository
    {
        private readonly string _connectionString;
            public RentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<RentRecord> GetAll()
        {
            List<RentRecord> result = new List<RentRecord>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<RentRecord>("SELECT * FROM RentRecord").ToList();
            }
                return result;
        }
        public void Add(RentRecord rentRecord)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute("INSERT INTO RentRecord (CreationDate, BookId, UserId, RentStart, RentEnd) VALUES (DEFAULT, @BookId, @UserId, @RentStart, @RentEnd)", rentRecord);
            }
        }
        public void EndRent(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                DateTime date = DateTime.Now;
                connection.Open();
                connection.Execute("UPDATE RentRecord SET RentEnd = @date WHERE Id = @id", new { id, date } );
            }
        }
        public RentRecord? GetActiveRentByClient(int clientId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DateTime date = DateTime.Now;
                return connection.QueryFirst<RentRecord>("SELECT * FROM RentRecord WHERE UserId = @clientId AND RentStart <= @date AND RentEnd >= @date", new { date, clientId });
            }
        }
        public List<RentRecord> GetAllRentsByClient(int clientId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                DateTime date = DateTime.Now;
                return connection.Query<RentRecord>("SELECT * FROM RentRecord WHERE UserId = @clientId", new { clientId }).ToList();
            }
        }
        public List<User> GetAllClientsByBook(int bookId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Query<User>("SELECT * FROM Users INNER JOIN RentRecord ON Users.UserId = RentRecord.UserId WHERE RentRecord.BookId = @bookId", new { bookId }).ToList();
            }
        }
    }
}
