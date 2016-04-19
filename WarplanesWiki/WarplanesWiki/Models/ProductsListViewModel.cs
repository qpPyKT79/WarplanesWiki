using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarplainsDomain.Entities;

namespace WarplanesWiki.Models
{
    public class WarplanesListViewModel
    {
        public IEnumerable<Warplane> Warplanes { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int CurrentPlaneCategory { get; set; }

        public string CurrentCountry { get; set; }
    }
}