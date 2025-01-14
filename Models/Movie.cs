using CinemaAplicatieWEB.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Movie
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Duration { get; set; }
    public string Genres { get; set; } = string.Empty; // Ensure this is comma-separated for multiple genres
    public List<Showtime> Showtime { get; set; } = new List<Showtime>(); // Navigation property

}
