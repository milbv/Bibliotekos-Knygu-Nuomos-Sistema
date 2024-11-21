using LibraryAPI.Core.Models;

namespace LibraryAPI.Core.Contracts
{
    public interface IRentRepository
    {
        List<RentRecord> GetAll();
        void Add(RentRecord rentRecord);
        void EndRent(int id);
        RentRecord? GetActiveRentByClient(int clientId);
        List<RentRecord> GetAllRentsByClient(int clientId);
        List<User> GetAllClientsByBook(int bookId);
    }
}
