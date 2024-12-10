using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_MP1.Data;
using Proiect_MP1.Models;

namespace Proiect_MP1.Pages.Registrations
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public CreateModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var eventList = _context.Eveniment
             .Include(b => b.EventPlanner)
             .Select(x => new
             {
                 x.ID,
                 EventFullName = x.Nume + " - " + x.EventPlanner.EventPlannerName
             });

            ViewData["EvenimentID"] = new SelectList(eventList, "ID", "EventFullName");
            ViewData["UserID"] = new SelectList(_context.User, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Registration Registration { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Registration.Add(Registration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
