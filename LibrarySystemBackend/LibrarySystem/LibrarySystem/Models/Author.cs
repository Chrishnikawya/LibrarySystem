namespace LibrarySystem.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; } 
        public string AuthorAddress { get; set; } 
        public string AuthorEmail { get; set; }
        public virtual ICollection <Book> Books { get; set; }
    }
}
