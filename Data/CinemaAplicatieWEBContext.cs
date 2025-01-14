using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Data
{
    public class CinemaAplicatieWEBContext : DbContext
    {
        public CinemaAplicatieWEBContext(DbContextOptions<CinemaAplicatieWEBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Hall> Halls { get; set; }
        public DbSet<Showtime> Showtime { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Hall>().ToTable("Halls");
            modelBuilder.Entity<Showtime>()
                        .HasOne(s => s.Movie)
                        .WithMany(m => m.Showtime)
                        .HasForeignKey(s => s.MovieId);
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Showtime>().ToTable("Showtime");
        }
    }

}


