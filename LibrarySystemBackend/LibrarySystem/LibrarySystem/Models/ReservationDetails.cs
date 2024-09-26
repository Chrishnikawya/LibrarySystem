using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    [Keyless]
    public class ReservationDetails
    {
        public string Status { get; set; }
        public DateTime ReservationDate { get; set; }
        public int StaffID { get; set; }
        public int BookID { get; set; }
        public int MemberID { get; set; }
        public string StaffName { get; set; }
        public string BookName { get; set; }
        public string MemberName { get; set; }
    }
}
