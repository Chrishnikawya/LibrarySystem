namespace LibrarySystem.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; } 
        public string MemberEmail { get; set; } 
        public string MemberPhoneNumber { get; set; } 
        public ICollection<Resevation> Resevations { get; set; }
    }
}
