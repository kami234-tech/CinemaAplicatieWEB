namespace CinemaAplicatieWEB.Models
{
    public class Showtime
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public DateTime DateTime { get; set; }
        public int HallId { get; set; }

        // Navigation Properties
        public Movie Movie { get; set; }
        public Hall Hall { get; set; } // Add this property if missing
    }
}
