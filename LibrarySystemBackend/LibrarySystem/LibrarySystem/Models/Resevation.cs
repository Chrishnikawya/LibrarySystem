﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class ResevationViewModel
    {
        [Key] 
        public int ReservationID { get; set; }
        public int MemberID { get; set; }
        public MemberViewModel Member { get; set; }
        public int StaffID { get; set; }
        public StaffViewModel Staff { get; set; }
        public int BookID { get; set; }
        public BookViewModel Book { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; } 
    }
}
