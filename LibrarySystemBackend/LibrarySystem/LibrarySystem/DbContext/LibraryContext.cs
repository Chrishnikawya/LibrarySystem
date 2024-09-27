using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LibrarySystem.Configuration;

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
        public DbSet<ReservationDetails> ReservationDetails { get; set; }
        public DbSet<BookDetails> BookDetails { get; set; }
        public LibraryContext(DbContextOptions options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(f => f.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            FluentConfiguration.Configure(modelBuilder);
        }
    }

}
