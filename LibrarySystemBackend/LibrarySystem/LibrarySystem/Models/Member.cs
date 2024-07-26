﻿namespace LibrarySystem.Models
{
    public class MemberViewModel
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; } 
        public string MemberEmail { get; set; } 
        public string MemberPhoneNumber { get; set; } 
        public ICollection<ResevationViewModel> Resevations { get; set; }
    }
}
