namespace LibrarySystem.Models
{
    public class Publisher
    {
        public int PublisherID { get; set; }
        public string PublisherName { get; set; } = string.Empty;
        public string PublisherAddress { get; set; } = string.Empty;
        public string PublisherEmail { get; set; } = string.Empty;
        public string PublisherPhoneNumber { get; set; } = string.Empty;
        public ICollection<Book> Books { get; set; }
        
    }
}
