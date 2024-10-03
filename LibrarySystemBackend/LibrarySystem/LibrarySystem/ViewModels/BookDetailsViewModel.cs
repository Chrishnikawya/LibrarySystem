namespace LibrarySystem.ViewModels
{
    public class BookDetailsViewModel
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int CategoryID { get; set; }
        public int AuthorID { get; set; }
        public int PublisherID { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }

    }
}
