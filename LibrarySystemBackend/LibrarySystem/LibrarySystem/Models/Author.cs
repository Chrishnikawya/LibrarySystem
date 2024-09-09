using LibrarySystem.Common;

namespace LibrarySystem.Models
{
    public class Author :DateTrackedEntity
    {
        public string AuthorName { get; set; } 
        public string AuthorAddress { get; set; } 
        public string AuthorEmail { get; set; }
        public string AuthorPhoneNumber{ get; set; }
        public virtual ICollection <Book> Books { get; set; }

    }
}
