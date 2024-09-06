using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using LibrarySystem.Common;

namespace LibrarySystem.Models
{
    public class Reservation : DateTrackedEntity
    {
        public int MemberID { get; set; }
        public Member Member { get; set; }
        public int StaffID { get; set; }
        public Staff Staff { get; set; }
        public int BookID { get; set; }
        public Book Book { get; set; }
        public DateTime ReservationDate { get; set; } 
        public string Status { get; set; } 
    }
}
