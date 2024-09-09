using LibrarySystem.Common;

namespace LibrarySystem.Models
{
    public class Staff : DateTrackedEntity
    {
        public string StaffName { get; set; } 
        public string StaffEmail { get; set;} 
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
