using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Models;
using CinemaAplicatieWEB.Data;

namespace CinemaAplicatieWEB.Pages.Showtimes
{
    public class DetailsModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public DetailsModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        public Showtime Showtime { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Showtime = await _context.Showtime.Include(s => s.Movie).Include(s => s.Hall).FirstOrDefaultAsync(m => m.Id == id);

            if (Showtime == null)
                return NotFound();

            return Page();
        }
    }
}
