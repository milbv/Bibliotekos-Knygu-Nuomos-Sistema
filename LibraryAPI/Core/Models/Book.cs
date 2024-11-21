namespace LibraryAPI.Core.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public decimal RentPrice { get; set; }
        
        public Book(int id, DateTime creationDate, string name, string author, string category, decimal rentPrice)
            :base(id, creationDate)
        {
            Name = name;
            Author = author;
            Category = category;
            RentPrice = rentPrice;
        }
        public Book()
        {

        }
    }
}
