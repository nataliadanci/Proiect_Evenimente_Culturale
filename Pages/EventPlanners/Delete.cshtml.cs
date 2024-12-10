using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MP1.Data;
using Proiect_MP1.Models;

namespace Proiect_MP1.Pages.EventPlanners
{
    public class DeleteModel : PageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public DeleteModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public EventPlanner EventPlanner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventplanner = await _context.EventPlanner.FirstOrDefaultAsync(m => m.ID == id);

            if (eventplanner == null)
            {
                return NotFound();
            }
            else
            {
                EventPlanner = eventplanner;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventplanner = await _context.EventPlanner.FindAsync(id);
            if (eventplanner != null)
            {
                EventPlanner = eventplanner;
                _context.EventPlanner.Remove(EventPlanner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
