using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MP1.Data;
using Proiect_MP1.Models;
using Proiect_MP1.Models.ViewModels;

namespace Proiect_MP1.Pages.EventPlanners
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public IndexModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        public IList<EventPlanner> EventPlanner { get; set; } = default!;

        public EventPlannerIndexData EventPlannerData { get; set; }
        public int EventPlannerID { get; set; }
        public int EventID { get; set; }
        public async Task OnGetAsync(int? id, int? eventID)
        {
            EventPlannerData = new EventPlannerIndexData();
            EventPlannerData.EventPlanners = await _context.EventPlanner
                .Include(i => i.Evenimente)
                .OrderBy(i => i.LastName) 
                .ThenBy(i => i.FirstName) 
                .ToListAsync();
            if (id != null)
            {
                EventPlannerID = id.Value;
                EventPlanner eventplanner = EventPlannerData.EventPlanners
                .Where(i => i.ID == id.Value).Single();
                EventPlannerData.Evenimente = eventplanner.Evenimente;
            }
        }
    }
}

