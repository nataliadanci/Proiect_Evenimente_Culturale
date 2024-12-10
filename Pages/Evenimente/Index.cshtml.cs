using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MP1.Data;
using Proiect_MP1.Models;

namespace Proiect_MP1.Pages.Evenimente
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public IndexModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        public IList<Eveniment> Eveniment { get; set; } = default!;

        public EventData EventD { get; set; }
        public int EventID { get; set; }
        public int CategoryID { get; set; }
        public string NumeSort { get; set; }
        public string EventPlannerSort { get; set; }

        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            EventD = new EventData();

            NumeSort = String.IsNullOrEmpty(sortOrder) ? "nume_desc" : "";
            EventPlannerSort = sortOrder == "eventplanner" ? "eventplanner_desc" : "";

            CurrentFilter = searchString;


            var evenimenteQuery = _context.Eveniment
                .Include(b => b.EventPlanner) 
                .Include(b => b.EventCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking();

            if (!String.IsNullOrEmpty(searchString))
            {
                evenimenteQuery = evenimenteQuery.Where(s =>
                    s.EventPlanner != null &&
                    (s.EventPlanner.FirstName.Contains(searchString) ||
                     s.EventPlanner.LastName.Contains(searchString) ||
                     s.Nume.Contains(searchString)));
            }

            evenimenteQuery = sortOrder switch
            {
                "nume_desc" => evenimenteQuery.OrderByDescending(s => s.Nume),
                "eventplanner_desc" => evenimenteQuery.OrderByDescending(s => s.EventPlanner != null ? s.EventPlanner.EventPlannerName : string.Empty),
                "eventplanner" => evenimenteQuery.OrderBy(s => s.EventPlanner != null ? s.EventPlanner.EventPlannerName : string.Empty),
                _ => evenimenteQuery.OrderBy(s => s.Nume),
            };

            EventD.Evenimente = await evenimenteQuery.ToListAsync();

            if (id != null)
            {
                EventID = id.Value;
                var eveniment = EventD.Evenimente.FirstOrDefault(e => e.ID == id.Value);
                if (eveniment?.EventCategories != null)
                {
                    EventD.Categories = eveniment.EventCategories.Select(s => s.Category);
                }
            

                switch (sortOrder)
                {
                    case "nume_desc":
                        EventD.Evenimente = EventD.Evenimente.OrderByDescending(s =>
                       s.Nume);
                        break;
                    case "eventplanner_desc":
                        EventD.Evenimente = EventD.Evenimente.OrderByDescending(s =>
                       s.EventPlanner.EventPlannerName);
                        break;
                    case "eventplanner":
                        EventD.Evenimente = EventD.Evenimente.OrderBy(s =>
                       s.EventPlanner.EventPlannerName);
                        break;
                    default:
                        EventD.Evenimente = EventD.Evenimente.OrderBy(s => s.Nume);
                        break;
                }
            }
        }
    }
}
