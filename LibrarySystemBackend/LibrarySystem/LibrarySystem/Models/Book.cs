using LibrarySystem.Common;

namespace LibrarySystem.Models
{
    public class Book :DateTrackedEntity
    {
        public string BookName { get; set; } 
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }
        public int PublisherID { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection <Reservation>Reservations { get; set; }


    }
}
