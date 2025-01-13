using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly CinemaAplicatieWEB.Data.CinemaAplicatieWEBContext _context;

        public CreateModel(CinemaAplicatieWEB.Data.CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ShowtimeId"] = new SelectList(_context.Set<Showtime>(), "Id", "Id");
        ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
