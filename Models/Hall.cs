namespace CinemaAplicatieWEB.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Layout { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }

}
