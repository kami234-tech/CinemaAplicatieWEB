namespace CinemaAplicatieWEB.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ShowtimeId { get; set; }
        public string Seats { get; set; } // E.g., "A1,A2,A3"
        public DateTime ReservationTime { get; set; } // Add this property if missing

        // Navigation Properties
        public User User { get; set; }
        public Showtime Showtime { get; set; }
    }
}
