namespace LibraryAPI.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }

        public BaseEntity()
        {

        }
        public BaseEntity(int id, DateTime creationDate)
        {
            Id = id;
            CreationDate = creationDate;
        }
    }
}
