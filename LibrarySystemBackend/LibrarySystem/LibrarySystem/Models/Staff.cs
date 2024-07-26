namespace LibrarySystem.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string StaffName { get; set; } 
        public string StaffEmail { get; set;} 
        public DateTime EnrollmentDate { get; set; }
        public ICollection<Resevation> Resevations { get; set; }
    }
}
