namespace LibrarySystem.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<Resevation> Resevations { get; set; }
    }
}
