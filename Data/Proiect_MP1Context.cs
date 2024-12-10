using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_MP1.Models;

namespace Proiect_MP1.Data
{
    public class Proiect_MP1Context : DbContext
    {
        public Proiect_MP1Context (DbContextOptions<Proiect_MP1Context> options)
            : base(options)
        {
        }

        public DbSet<Proiect_MP1.Models.Eveniment> Eveniment { get; set; } = default!;
        public DbSet<Proiect_MP1.Models.Category> Category { get; set; } = default!;
        public DbSet<Proiect_MP1.Models.EventPlanner> EventPlanner { get; set; } = default!;
        public DbSet<Proiect_MP1.Models.User> User { get; set; } = default!;
        public DbSet<Proiect_MP1.Models.Registration> Registration { get; set; } = default!;
    }
}
