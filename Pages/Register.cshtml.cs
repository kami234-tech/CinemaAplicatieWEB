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
        public string Name { get; set; }
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
            // Validate required fields
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Role))
            {
                ErrorMessage = "All fields are required.";
                return Page();
            }

            // Validate secret password if role is "admin"
            if (Role == "admin" && SecretPassword != "CinemaCity")
            {
                ErrorMessage = "The secret password for Admin is incorrect.";
                return Page();
            }

            // Check if a user with the same email already exists
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == Email); // Change `User` to `Users`
            if (existingUser != null)
            {
                ErrorMessage = "A user with this email already exists.";
                return Page();
            }

            // Add the new user to the database
            var newUser = new User
            {
                Name = Name,
                Email = Email,
                Password = Password, // Consider encrypting the password
                Role = Role
            };
            _context.Users.Add(newUser); // Change `User` to `Users`
            await _context.SaveChangesAsync();

            return RedirectToPage("/Login");
        }
    }
}
