namespace LibraryAPI.Core.Models
{
    public class PaperBook : Book
    {
        public int CopyAmount { get; set; }
        public string ISBN { get; set; }

        public PaperBook(int id, DateTime creationDate, string name, string author, string category, decimal rentPrice, int copyAmount, string isbn)
            : base(id, creationDate, name, author, category, rentPrice)
        {
            CopyAmount = copyAmount;
            ISBN = isbn;
        }
        public PaperBook()
        {

        }
    }
}
