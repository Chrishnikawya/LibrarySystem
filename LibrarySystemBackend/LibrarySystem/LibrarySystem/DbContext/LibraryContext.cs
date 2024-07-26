using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibrarySystem.DbContext
{
    public class LibraryContext : IdentityDbContext
    {
        public DbSet<MemberViewModel> Members { get; set; }
        public DbSet<ResevationViewModel> Resevations { get; set; }
        public DbSet<StaffViewModel> Staffs { get; set; }
        public DbSet<PublisherViewModel> Publishers { get; set; }
        public DbSet<BookViewModel> Books { get; set; }
        public DbSet<AuthorViewModel> Authors { get; set; }
        public LibraryContext(DbContextOptions options)
: base(options)
        {
        }   
    }

}
