using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly CinemaAplicatieWEB.Data.CinemaAplicatieWEBContext _context;

        public EditModel(CinemaAplicatieWEB.Data.CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; } = default!;

        // Only one OnPostAsync method is needed
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(User).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(User.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the user from the database
            User = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }


        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id); // Check if the user exists in the database
        }
    }
}
