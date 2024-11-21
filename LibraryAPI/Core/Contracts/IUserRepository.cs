using LibraryAPI.Core.Models;

namespace LibraryAPI.Core.Contracts
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(int id);
    }
}
