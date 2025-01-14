using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Pages.Showtimes
{
    public class EditModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public EditModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Showtime Showtime { get; set; }

        public List<Movie> Movies { get; set; }
        public List<Hall> Halls { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Showtime = await _context.Showtime
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (Showtime == null)
            {
                return NotFound();
            }

            Movies = await _context.Movies.ToListAsync();
            Halls = await _context.Halls.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Movies = await _context.Movies.ToListAsync();
                Halls = await _context.Halls.ToListAsync();
                return Page();
            }

            _context.Attach(Showtime).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
