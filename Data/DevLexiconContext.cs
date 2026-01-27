using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DevLexicon.Models;

namespace DevLexicon.Data
{
    public class DevLexiconContext : DbContext
    {
        public DevLexiconContext (DbContextOptions<DevLexiconContext> options)
            : base(options)
        {
        }

        public DbSet<DevLexicon.Models.TechTerm> TechTerm { get; set; } = default!;
    }
}
