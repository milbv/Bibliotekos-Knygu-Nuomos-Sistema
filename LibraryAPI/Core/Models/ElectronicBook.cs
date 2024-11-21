namespace LibraryAPI.Core.Models
{
    public class ElectronicBook : Book
    {
        public string FileFormat { get; set; }
        public double FileSizeMb { get; set; }

        public ElectronicBook(int id, DateTime creationDate, string name, string author, string category, decimal rentPrice, string fileFormat, double fileSizeMb)
            :base(id, creationDate, name, author, category, rentPrice)
        {
            FileFormat = fileFormat;
            FileSizeMb = fileSizeMb;
        }
        public ElectronicBook()
        {

        }
    }
}
