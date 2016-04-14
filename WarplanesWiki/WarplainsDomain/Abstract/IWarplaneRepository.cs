using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarplainsDomain.Entities;

namespace WarplainsDomain.Abstract
{
    public interface IWarplaneRepository
    {
        IQueryable<Warplane> Warplanes { get; }
    }
}
