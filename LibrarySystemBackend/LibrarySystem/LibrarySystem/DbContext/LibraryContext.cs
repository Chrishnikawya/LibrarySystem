using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibrarySystem.DbContext
{
    public class LibraryContext : IdentityDbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public LibraryContext(DbContextOptions options)
: base(options)
        {
        }   
    }

}
