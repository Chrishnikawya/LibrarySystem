namespace LibrarySystem.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string StaffName { get; set; } = string.Empty;
        public string Email { get; set;} = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Resevation> Resevations { get; set; }
    }
}
