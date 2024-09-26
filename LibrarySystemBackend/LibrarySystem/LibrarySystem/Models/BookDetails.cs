using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models
{
    public class BookDetails
    {
        public string BookName { get; set; }
        [Key]
        public int Id { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string PublisherName { get; set; }
        public string CategoryName { get; set; }
        public int PublisherID { get; set; }
        public int CategoryID { get; set; }
    }
}

