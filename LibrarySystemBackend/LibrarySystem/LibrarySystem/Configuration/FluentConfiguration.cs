
using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Configuration
{
    public static class FluentConfiguration
    {
      public static void Configure(ModelBuilder modelBuilder)
        {

            #region Reservation Configuration
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(r => r.Id); 
                entity.Property(r => r.Id).ValueGeneratedOnAdd(); 

                entity.HasOne(r => r.Staff)
                      .WithMany(s => s.Reservations)
                      .HasForeignKey(r => r.StaffID)
                      .IsRequired();

                entity.HasOne(r => r.Member)
                      .WithMany(m => m.Reservations)
                      .HasForeignKey(r => r.MemberID)
                      .IsRequired();

                entity.HasOne(r => r.Book)
                      .WithMany(b => b.Reservations)
                      .HasForeignKey(r => r.BookID)
                      .IsRequired();
                entity.ToTable("Reservations");
            });

            #endregion

            #region Book Configuration
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Id).ValueGeneratedOnAdd(); 

                entity.HasOne(b => b.Author)
                      .WithMany(a => a.Books)
                      .HasForeignKey(b => b.AuthorID)
                      .IsRequired();

                entity.HasOne(b => b.Category)
                      .WithMany(c => c.Books)
                      .HasForeignKey(b => b.CategoryID)
                      .IsRequired();

                entity.HasOne(b => b.Publisher)
                      .WithMany(p => p.Books)
                      .HasForeignKey(b => b.PublisherID)
                      .IsRequired();
                entity.ToTable("Books");
            });
            #endregion


        }
        

    }
}