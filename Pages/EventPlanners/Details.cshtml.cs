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
    public class DetailsModel : PageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public DetailsModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

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
    }
}
