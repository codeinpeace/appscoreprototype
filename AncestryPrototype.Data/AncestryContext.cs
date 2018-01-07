using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AncestryPrototype.Model;
using Microsoft.EntityFrameworkCore;



namespace AncestryPrototype.Data
{
    public class AncestryContext : DbContext
    {
        public AncestryContext(DbContextOptions<AncestryContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Place> Places { get; set; }
    }
  
}
