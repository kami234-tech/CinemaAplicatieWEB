using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Pages.Showtimes
{
    public class IndexModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public IndexModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        public IList<Showtime> Showtimes { get; set; }

        public async Task OnGetAsync()
        {
            Showtimes = await _context.Showtime
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .ToListAsync();
        }
    }
}
