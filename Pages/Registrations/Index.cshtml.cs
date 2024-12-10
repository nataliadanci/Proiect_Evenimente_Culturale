using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_MP1.Data;
using Proiect_MP1.Models;

namespace Proiect_MP1.Pages.Registrations
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_MP1.Data.Proiect_MP1Context _context;

        public IndexModel(Proiect_MP1.Data.Proiect_MP1Context context)
        {
            _context = context;
        }

        public IList<Registration> Registration { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Registration = await _context.Registration
                .Include(r => r.Eveniment)
                    .ThenInclude(r => r.EventPlanner)
                .Include(r => r.User).ToListAsync();
        }
    }
}
