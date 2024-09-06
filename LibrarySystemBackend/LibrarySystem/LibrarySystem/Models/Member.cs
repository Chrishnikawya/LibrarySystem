using LibrarySystem.Common;
namespace LibrarySystem.Models
{
    public class Member : DateTrackedEntity
    {
        //public int MemberID { get; set; }
        public string MemberName { get; set; } 
        public string MemberEmail { get; set; } 
        public string MemberPhoneNumber { get; set; } 
        public ICollection<Reservation> Reservations { get; set; }

    }
}
