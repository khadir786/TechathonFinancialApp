using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechathonFinancial.Models;

namespace TechathonFinancial.Data
{
    public class WordDbContext : DbContext
    {
        public WordDbContext (DbContextOptions<WordDbContext> options)
            : base(options)
        {
        }

        public DbSet<TechathonFinancial.Models.WordDefinition> WordDefinition { get; set; } = default!;
    }
}
