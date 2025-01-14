using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Pages.Halls
{
    public class DetailsModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public DetailsModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        public Hall Hall { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the hall with the specified id
            Hall = await _context.Halls.FirstOrDefaultAsync(h => h.Id == id);

            if (Hall == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
