using LibrarySystem.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.ViewModels
{
    public class ResevationViewModel
    {
        [Key] 
        public int ReservationID { get; set; }
        public int MemberID { get; set; }
        public int StaffID { get; set; }
        public int BookID { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } 
    }
}
