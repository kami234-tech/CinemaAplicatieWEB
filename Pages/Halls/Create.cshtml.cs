using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CinemaAplicatieWEB.Pages.Halls
{
    public class CreateModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        public CreateModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        // Property to bind the form data
        [BindProperty]
        public Hall Hall { get; set; }

        // This method runs on GET request
        public IActionResult OnGet()
        {
            return Page();
        }

        // This method runs when the form is submitted (POST request)
        public async Task<IActionResult> OnPostAsync()
        {
            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                return Page(); // If not valid, return the page with validation errors
            }

            // Add the new hall to the context and save to the database
            _context.Halls.Add(Hall);
            await _context.SaveChangesAsync();

            // After adding, redirect to the Hall index page
            return RedirectToPage("./Index");
        }
    }
}
