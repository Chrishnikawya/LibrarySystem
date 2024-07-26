namespace LibrarySystem.Models
{
    public class BookViewModel
    {
        public int BookID { get; set; }
        public string BookName { get; set; } 
        public string Category { get; set; } 
        public int AuthorID { get; set; }
        public virtual AuthorViewModel Author { get; set; }
        public int PublisherID { get; set; }
        public virtual PublisherViewModel Publisher { get; set; }
        public virtual ICollection <ResevationViewModel>Resevations { get; set; }
    }
}
