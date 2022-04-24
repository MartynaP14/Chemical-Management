using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chemical_Management.Models;

namespace Chemical_Management.Data
{
    public class Chemical_ManagementContext : DbContext
    {
        public Chemical_ManagementContext (DbContextOptions<Chemical_ManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Chemical_Management.Models.Reagent> Reagent { get; set; }

        public DbSet<Chemical_Management.Models.Lab> Lab { get; set; }

        public DbSet<Chemical_Management.Models.Supply> Supply { get; set; }
    }
}
