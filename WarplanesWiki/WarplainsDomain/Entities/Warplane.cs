using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarplainsDomain.Entities
{
    public class Warplane
    {
        public int WarplaneID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string PlaneImageUrl { get; set; }
        public PlaneGeneration Generation { get; set; }
        public WarplaneCategoty Category { get; set; }
        public int Crew { get; set; }
        public double Length { get; set; }
        public double Wingspan { get; set; } // 14m
        public double Height { get; set; } //: 4.8 m
        public double WingArea { get; set; } //: 82 m²
        public double EmptyWeight { get; set; } // 18,500 kg
        public double MaximumWeight { get; set; } //: 37,000 kg
        public double FuelWeight { get; set; } //: 11,100 kg
        public string EngineName { get; set; } // "AL-41F1"
        public string EngineDescription { get; set; } // Turbofan with afterburner and thrust vector control
        public double EngineWeight { get; set; } //: 1350 kg
        public double MaximumSpeed { get; set; } // at an altitude of 2600 km / h
        public double MaxRange { get; set; } //: 4300 km
        public double FlightDuration { get; set; } //: up to 5.8 x
        public double Ceiling { get; set; } //: 20000 m
        public override int GetHashCode() => WarplaneID.GetHashCode()*Name.GetHashCode();
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Warplane p = (Warplane)obj;
                return (Name == p.Name) && (WarplaneID == p.WarplaneID);
            }
        }

        public override string ToString() => $"Id: {WarplaneID}, name: {Name}";
    }
    public enum PlaneGeneration
    {
        [Display(Name = "1")]
        [Description("1")]
        First = 0,
        [Display(Name = "2")]
        [Description("2")]
        Second = 1,
        [Display(Name = "3")]
        [Description("3")]
        Third = 2,
        [Display(Name = "4")]
        [Description("4")]
        Fourth = 3,
        [Display(Name = "4+")]
        [Description("4+")]
        FourthPlus = 4,
        [Display(Name = "5")]
        [Description("5")]
        Fifth = 5
    }
    public enum WarplaneCategoty
    {
        [Display(Name = "")]
        Unknown = 0,
        [Display(Name = "Штурмовик")]
        [Description("Штурмовик")]
        Hedgehopper = 1,
        [Display(Name = "Истребитель")]
        [Description("Истребитель")]
        Fighter = 2,
        [Display(Name = "Бомбардировщик")]
        [Description("Бомбардировщик")]
        Bomber = 3,
        [Display(Name = "Истребитель-бомбардировщик")]
        [Description("Истребитель-бомбардировщик")]
        FighterBomber = 4,
        [Display(Name = "Разведывательная авиация")]
        [Description("Разведывательная авиация")]
        Scout = 5,
        [Display(Name = "Беспилотный летательный аппарат")]
        [Description("Беспилотный летательный аппарат")]
        UAV = 6,
        [Display(Name = "Транспортная авиация")]
        [Description("Транспортная авиация")]
        TransportAircraft = 7
    }

}
