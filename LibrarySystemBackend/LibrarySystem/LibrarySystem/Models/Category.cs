using LibrarySystem.Common;
namespace LibrarySystem.Models
{
    public class Category : DateTrackedEntity
    {
       
        public string CategoryName { get; set; }
        public ICollection<Book> Books { get; set; }
      
    }
}

