using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_MP1.Data;
using Proiect_MP1.Models;

namespace Proiect_MP1.Pages.Evenimente
{
    public class EditModel : EventCategoriesPageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public EditModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Eveniment Eveniment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Eveniment = await _context.Eveniment
             .Include(b => b.EventPlanner)
             .Include(b => b.EventCategories).ThenInclude(b => b.Category)
             .AsNoTracking()
             .FirstOrDefaultAsync(m => m.ID == id);

            var eveniment =  await _context.Eveniment.FirstOrDefaultAsync(m => m.ID == id);
            if (eveniment == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Eveniment);

            Eveniment = eveniment;
            ViewData["EventPlannerID"] = new SelectList(_context.Set<EventPlanner>(), "ID","EventPlannerName");
            return Page();
        }
        
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            //se va include Author conform cu sarcina de la lab 2
            var eventToUpdate = await _context.Eveniment
                .Include(i => i.EventPlanner)
                .Include(i => i.EventCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);
            if (eventToUpdate == null)
            {
                return NotFound();
            }
            //se va modifica AuthorID conform cu sarcina de la lab 2
            if (await TryUpdateModelAsync<Eveniment>(
            eventToUpdate,
            "Eveniment",
            i => i.Nume, i => i.EventPlannerID, i => i.Descriere, i => i.Locatie,
            i => i.Pret, i => i.DataInceput, i => i.DataSfarsit))
            {
                UpdateEventCategories(_context, selectedCategories, eventToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateEventCategories(_context, selectedCategories, eventToUpdate);
            PopulateAssignedCategoryData(_context, eventToUpdate);
            return Page();
        }
    }
}