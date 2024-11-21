namespace LibraryAPI.Core.Models
{
    public class RentRecord : BaseEntity
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime RentStart { get; set; }
        public DateTime RentEnd { get; set; }
        
        public RentRecord(int id, DateTime creationDate, int bookId, int userId, DateTime rentStart, DateTime rentEnd)
            :base (id, creationDate)
        {
            BookId = bookId;
            UserId = userId;
            RentStart = rentStart;
            RentEnd = rentEnd;
        }
        public RentRecord()
        {

        }
    }
}
