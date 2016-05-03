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

        public void SavePlane(Warplane plane)
        {
            if (plane.WarplaneID == 0)
            {
                context.Warplanes.Add(plane);
            }
            else
            {
                Warplane dbEntry = context.Warplanes.Find(plane.WarplaneID);
                if (dbEntry != null)
                {
                    dbEntry.Name = plane.Name;
                    dbEntry.Description = plane.Description;
                    dbEntry.Country = plane.Country;
                    dbEntry.Category = plane.Category;
                    dbEntry.Description = plane.Description;
                    dbEntry.PlaneImageUrl = plane.PlaneImageUrl;
                    dbEntry.Generation = plane.Generation;
                    dbEntry.Crew = plane.Crew;
                    dbEntry.Length = plane.Length;
                    dbEntry.Wingspan = plane.Wingspan;
                    dbEntry.Height = plane.Height;
                    dbEntry.WingArea = plane.WingArea;
                    dbEntry.EmptyWeight = plane.EmptyWeight;
                    dbEntry.MaximumWeight = plane.MaximumWeight;
                    dbEntry.FuelWeight = plane.FuelWeight;
                    dbEntry.EngineName = plane.EngineName;
                    dbEntry.EngineDescription = plane.EngineDescription;
                    dbEntry.EngineWeight = plane.EngineWeight;
                    dbEntry.MaximumSpeed = plane.MaximumSpeed;
                    dbEntry.MaxRange = plane.MaxRange;
                    dbEntry.FlightDuration = plane.FlightDuration;
                    dbEntry.Ceiling = plane.Ceiling;
                }
            }
            context.SaveChanges();
        }
        public void RemovePlane(int id)
        {
            var plane = context.Warplanes.Find(id);
            context.Warplanes.Remove(plane);
            context.SaveChanges();
        }
    }
}
