namespace LibrarySystem.Models
{
    public class Resevation
    {
       
        public int ReservationID { get; set; }
        public int MemberID { get; set; }
        public int StaffID { get; set; }
        public int BookID { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; } = string.Empty;

        public Member Member { get; set; } 
        public Staff Staff { get; set; }
        public Book Book { get; set; }
    }
}
