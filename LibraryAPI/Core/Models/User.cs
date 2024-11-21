namespace LibraryAPI.Core.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User(int id, DateTime creationDate, string name, string email)
            :base(id, creationDate)
        {
            Name = name;
            Email = email;
        }

        public User()
        {
        }
    }
}
