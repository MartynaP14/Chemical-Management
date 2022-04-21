using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Chemical_Management.Models;

namespace Chemical_Management.Data
{
    public class LabUserContext : DbContext
    {
        public LabUserContext (DbContextOptions<LabUserContext> options)
            : base(options)
        {
        }
        public DbSet<Chemical_Management.Models.LabAnalyst> LabAnalyst { get; set; }
        public DbSet<Chemical_Management.Models.Reagent> Reagent { get; set; }
        public DbSet<Chemical_Management.Models.Assay> Assay { get; set; }
    }
}
