﻿namespace LibrarySystem.Models
{
    public class PublisherViewModel
    {
        public int PublisherID { get; set; }
        public string PublisherName { get; set; } 
        public string PublisherAddress { get; set; } 
        public string PublisherEmail { get; set; } 
        public string PublisherPhoneNumber { get; set; } 
        public ICollection<BookViewModel> Books { get; set; }
        
    }
}