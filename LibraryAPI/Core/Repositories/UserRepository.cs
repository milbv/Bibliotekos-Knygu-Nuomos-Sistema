using Dapper;
using LibraryAPI.Core.Contracts;
using LibraryAPI.Core.Models;
using Microsoft.Data.SqlClient;

namespace LibraryAPI.Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<User> GetAll()
        {
            List<User> result = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                result = connection.Query<User>("SELECT * FROM Users").ToList();
            }
            return result;
        }
        public User? GetById(int id)
        {
            User result = new User();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                try
                {
                    result = connection.QueryFirst<User>("SELECT * FROM Users WHERE Id = @id", new { id });
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not find product by id " + id);
                }
                return result;
            }
        }
    }
}
