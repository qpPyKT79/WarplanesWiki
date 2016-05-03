using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarplainsDomain.Entities;

namespace WarplanesWiki.Models
{
    public class Comparison
    {
        private HashSet<Warplane> PlaneCollection = new HashSet<Warplane>();
        public void AddPlane(Warplane plane)
        {
            if (!PlaneCollection.Contains(plane))
                PlaneCollection.Add(plane);
        }

        public void RemovePlane(Warplane plane) => PlaneCollection.Remove(plane);

        public void Clear() => PlaneCollection.Clear();

        public HashSet<Warplane> Planes => PlaneCollection;
    }
}