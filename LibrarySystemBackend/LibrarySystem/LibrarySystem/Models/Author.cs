namespace LibrarySystem.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string AuthorAddress { get; set; } = string.Empty;
        public string AuthorEmail { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; }
    }
}
