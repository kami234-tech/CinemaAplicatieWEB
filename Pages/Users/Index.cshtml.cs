using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly CinemaAplicatieWEB.Data.CinemaAplicatieWEBContext _context;

        public IndexModel(CinemaAplicatieWEB.Data.CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        public IList<User> Users { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Replace _context.User with _context.Users
            Users = await _context.Users.ToListAsync();
        }
    }
}
