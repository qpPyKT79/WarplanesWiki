using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarplainsDomain.Abstract;
using WarplainsDomain.Entities;

namespace WarplainsDomain.Concrete
{
    public class EFWarplaneRepository : IWarplaneRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Warplane> Warplanes
        {
            get { return context.Warplanes; }
        }
    }
}
