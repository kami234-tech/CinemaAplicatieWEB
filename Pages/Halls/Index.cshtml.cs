using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;

namespace CinemaAplicatieWEB.Pages.Halls
{
    public class IndexModel : PageModel
    {
        private readonly CinemaAplicatieWEB.Data.CinemaAplicatieWEBContext _context;

        public IndexModel(CinemaAplicatieWEB.Data.CinemaAplicatieWEBContext context)
        {
            _context = context;
        }

        public IList<Hall> Hall { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Hall = await _context.Hall.ToListAsync();
        }
    }
}
