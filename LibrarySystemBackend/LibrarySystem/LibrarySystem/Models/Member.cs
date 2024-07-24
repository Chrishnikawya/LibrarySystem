namespace LibrarySystem.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public ICollection<Resevation> Resevations { get; set; }
    }
}
