using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;
        public RegisterModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Role { get; set; }
        [BindProperty]
        public string SecretPassword { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Role))
            {
                ErrorMessage = "Toate câmpurile sunt obligatorii.";
                return Page();
            }

            // Validare pentru parola secretă dacă rolul este Admin
            if (Role == "admin" && SecretPassword != "CinemaCity")
            {
                ErrorMessage = "Parola secretă pentru Admin este incorectă.";
                return Page();
            }

            // Verifică dacă utilizatorul există deja
            var existingUser = _context.User.FirstOrDefault(u => u.Email == Email);
            if (existingUser != null)
            {
                ErrorMessage = "Un utilizator cu acest email există deja.";
                return Page();
            }

            // Adaugă utilizatorul în baza de date
            var newUser = new User
            {
                Email = Email,
                Password = Password, // Parola poate fi criptată aici
                Role = Role
            };
            _context.User.Add(newUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Login");
        }
    }
}

