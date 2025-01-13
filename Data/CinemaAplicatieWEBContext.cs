using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Data
{
    public class CinemaAplicatieWEBContext : IdentityDbContext
    {
        public CinemaAplicatieWEBContext(DbContextOptions<CinemaAplicatieWEBContext> options)
            : base(options)
        {
        }

        public DbSet<Hall> Hall { get; set; } = default!;
        public DbSet<Movie> Movie { get; set; } = default!;
        public DbSet<Reservation> Reservation { get; set; } = default!;
        public DbSet<Showtime> Showtime { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apelăm metoda OnModelCreating de la IdentityDbContext pentru configurările Identity
            base.OnModelCreating(modelBuilder);

            // Configurarea proprietății Genres pentru tabela Movie
            var genresComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2), // Compară colecțiile prin elemente
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Calculează hash-ul
                c => c.ToList() // Creează o copie a colecției
            );

            modelBuilder.Entity<Movie>()
                .Property(m => m.Genres)
                .HasConversion(
                    v => string.Join(",", v), // Convertor pentru salvare în baza de date
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList() // Convertor pentru citire din baza de date
                )
                .Metadata.SetValueComparer(genresComparer); // Setează comparătorul
        }
    }
}
