using LibraryAPI.Core.Contracts;
using LibraryAPI.Core.Models;
using LibraryAPI.Core.Repositories;
using Serilog;

namespace LibraryAPI.Core.Services
{
    public class RentService : IRentService
    {
        private readonly IRentRepository _rentRepository;
        private readonly IBookRepository _bookRepository;
        public RentService(IRentRepository rentRepository, IBookRepository bookRepository)
        {
            _rentRepository = rentRepository;
            _bookRepository = bookRepository;
        }
        public List<RentRecord> GetAllRents()
        {
            return _rentRepository.GetAll();
        }
        public void AddRentRecord(RentRecord rentRecord)
        {
            List<Book> allBooks = new List<Book>(_bookRepository.GetAll());
            List<RentRecord> allRecords = new List<RentRecord>(GetAllRents());
            List<RentRecord> matchingRecords = new List<RentRecord>(allRecords.FindAll(a => a.BookId == rentRecord.BookId));
            PaperBook book = (PaperBook)allBooks.Find(a => a is PaperBook && a.Id == rentRecord.BookId);
            if (matchingRecords != null && book != null && book.CopyAmount < matchingRecords.Count())
            {
                Log.Error($"All books {book} are rented out.");
                
            }
            else
            {
                if (rentRecord.RentEnd < rentRecord.RentStart)
                {
                    Log.Error($"Start date {rentRecord.RentStart} is later than end date {rentRecord.RentEnd}");
                }
                else
                {
                    _rentRepository.Add(rentRecord);
                    Log.Information($"Rental record information: {rentRecord}");
                    if (rentRecord.RentEnd < DateTime.UtcNow && rentRecord.RentStart > DateTime.UtcNow)
                    {
                        Log.Information("Rental record is currently active");
                    }
                }
            }
        }
        public void EndRent(int id)
        {
            _rentRepository.EndRent(id);
        }
        public RentRecord? GetActiveRentByClient(int clientId) 
        {
            return _rentRepository.GetActiveRentByClient(clientId);
        }
        public List<RentRecord> GetAllRentsByClient(int clientId)
        {
            return _rentRepository.GetAllRentsByClient(clientId);
        }
        public List<User> GetAllClientsByBook(int bookId)
        {
            return _rentRepository.GetAllClientsByBook(bookId);
        }
    }
}
