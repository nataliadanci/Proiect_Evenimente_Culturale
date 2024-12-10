using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_MP1.Data;
using Proiect_MP1.Models;

namespace Proiect_MP1.Pages.Evenimente
{
    public class CreateModel : EventCategoriesPageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public CreateModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["EventPlannerID"] = new SelectList(_context.Set<EventPlanner>(), "ID", "EventPlannerName");
            var eveniment = new Eveniment();
            eveniment.EventCategories = new List<EventCategory>();
            PopulateAssignedCategoryData(_context, eveniment);
            return Page();
        }

        [BindProperty]
        public Eveniment Eveniment { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newEveniment = new Eveniment();
            if (selectedCategories != null)
            {
                newEveniment.EventCategories = new List<EventCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new EventCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newEveniment.EventCategories.Add(catToAdd);
                }
            }
            Eveniment.EventCategories = newEveniment.EventCategories;
            _context.Eveniment.Add(Eveniment);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
