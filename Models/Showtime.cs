using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CinemaAplicatieWEB.Models
{
    public class Showtime
    {
        [Key]
        public int Id { get; set; }

        public int MovieId { get; set; }
        public int HallId { get; set; }

        public DateTime? DateTime { get; set; } // Nullable DateTime field
        // New property
        public string Time { get; set; }  // Add this line for the new 'Time' column

        // Navigation properties
        public Movie Movie { get; set; }
        public Hall Hall { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
