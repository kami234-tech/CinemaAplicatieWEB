using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Pages.Halls
{
    public class IndexModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public IndexModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        public IList<Hall> Hall { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Hall = await _context.Halls.ToListAsync();
        }
    }
}
