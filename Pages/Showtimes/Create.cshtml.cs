using CinemaAplicatieWEB.Data;
using CinemaAplicatieWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAplicatieWEB.Pages.Showtimes
{
    public class CreateModel : PageModel
    {
        private readonly CinemaAplicatieWEBContext _context;

        // Add a constructor to initialize Showtime
        public CreateModel(CinemaAplicatieWEBContext context)
        {
            _context = context;
            Showtime = new Showtime();  // Initialize Showtime
        }

        [BindProperty]
        public Showtime Showtime { get; set; }

        public List<Movie> Movies { get; set; }
        public List<Hall> Halls { get; set; }

        public void OnGet()
        {
            Movies = _context.Movies.ToList();  // Get all movies from the database
            Halls = _context.Halls.ToList();    // Get all halls from the database

            List<SelectListItem> timeSlots = new List<SelectListItem>();
            TimeSpan startTime = TimeSpan.FromHours(10);  // Start at 10:00 AM
            TimeSpan endTime = TimeSpan.FromHours(22);   // End at 10:00 PM

            while (startTime <= endTime)
            {
                timeSlots.Add(new SelectListItem
                {
                    Text = startTime.ToString(@"hh\:mm"),  // Format time as "hh:mm"
                    Value = startTime.ToString(@"hh\:mm")  // Use same format for value
                });
                startTime = startTime.Add(TimeSpan.FromMinutes(150));  // Add 2:30 hours (150 minutes)
            }

            ViewData["TimeSlots"] = timeSlots;  // Store the time slots in ViewData for rendering in the view
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ensure that the 'Time' value is not null
            if (!string.IsNullOrEmpty(Request.Form["Time"]))
            {
                var selectedTime = Request.Form["Time"];
                TimeSpan timeSpan = TimeSpan.Parse(selectedTime);
                Showtime.DateTime = Showtime.DateTime?.Date.Add(timeSpan); // Set the correct DateTime value
            }

            _context.Showtime.Add(Showtime);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


    }

}
