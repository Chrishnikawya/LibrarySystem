namespace LibrarySystem.Models
{
    using Microsoft.EntityFrameworkCore;

    public class LibraryContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Resevation> Resevations { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=CHRISHI;Initial Catalog=LibrarySystem;Persist Security Info=True;TrustServerCertificate=True;User ID=sa;Password=ssa");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resevation>()
                .HasOne(r => r.Member)
                .WithMany(m => m.Resevations)
                .HasForeignKey(r => r.MemberID)
                .IsRequired();

            modelBuilder.Entity<Resevation>()
                .HasOne(r => r.Staff)
                .WithMany(s => s.Resevations)
                .HasForeignKey(r => r.StaffID)
                .IsRequired();

            modelBuilder.Entity<Resevation>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Resevations)
                .HasForeignKey(r => r.BookID)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }

}
