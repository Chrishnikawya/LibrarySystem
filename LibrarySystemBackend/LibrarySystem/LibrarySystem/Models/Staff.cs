﻿namespace LibrarySystem.Models
{
    public class StaffViewModel
    {
        public int StaffID { get; set; }
        public string StaffName { get; set; } 
        public string StaffEmail { get; set;} 
        public DateTime EnrollmentDate { get; set; }
        public ICollection<ResevationViewModel> Resevations { get; set; }
    }
}