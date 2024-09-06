using LibrarySystem.Common;
namespace LibrarySystem.Models
{
    public class Publisher : DateTrackedEntity
    {
        public string PublisherName { get; set; } 
        public string PublisherAddress { get; set; } 
        public string PublisherEmail { get; set; } 
        public string PublisherPhoneNumber { get; set; } 
        public ICollection<Book> Books { get; set; }

        
    }
}
