using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarplainsDomain.Entities;

namespace WarplainsDomain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Warplane> Warplanes { get; set; }

    }
}
