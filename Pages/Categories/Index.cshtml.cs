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

namespace Proiect_MP1.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public IndexModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
            .Include(c => c.EventCategories)
              .ThenInclude(bc => bc.Eveniment)
              .ThenInclude(b => b.EventPlanner)
            .OrderBy(c => c.CategoryName)
            .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(c => c.ID == id.Value).Single();
                CategoryData.Evenimente = category.EventCategories.Select(bc => bc.Eveniment);
            }
        }
    }
}