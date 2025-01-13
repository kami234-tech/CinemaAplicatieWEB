using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace CinemaAplicatieWEB.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; } // In minutes
        public List<string> Genres { get; set; } = new List<string>(); // Listă de genuri
    }
}
