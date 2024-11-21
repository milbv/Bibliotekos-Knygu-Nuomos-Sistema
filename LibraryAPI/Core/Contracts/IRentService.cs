using LibraryAPI.Core.Models;

namespace LibraryAPI.Core.Contracts
{
    public interface IRentService
    {
        List<RentRecord> GetAllRents();
        void AddRentRecord(RentRecord rentRecord);
        void EndRent(int id);
        RentRecord? GetActiveRentByClient(int clientId);
        List<RentRecord> GetAllRentsByClient(int clientId);
        List<User> GetAllClientsByBook(int bookId);
    }
}
