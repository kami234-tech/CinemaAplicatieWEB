using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Pages.Halls
{
    public class DeleteModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public DeleteModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hall Hall { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Retrieve the hall to confirm deletion
            Hall = await _context.Halls.FirstOrDefaultAsync(h => h.Id == id);

            if (Hall == null)
            {
                return NotFound();
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hall = await _context.Halls.FindAsync(id);

            if (Hall != null)
            {
                _context.Halls.Remove(Hall);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
