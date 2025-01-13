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
    public class DetailsModel : PageModel
    {
        private readonly CinemaAplicatieWEB.Data.CinemaAplicatieWEBContext _context;

        public DetailsModel(CinemaAplicatieWEB.Data.CinemaAplicatieWEBContext context)
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

            var hall = await _context.Hall.FirstOrDefaultAsync(m => m.Id == id);
            if (hall == null)
            {
                return NotFound();
            }
            else
            {
                Hall = hall;
            }
            return Page();
        }
    }
}
