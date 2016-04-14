using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarplainsDomain.Entities
{
    public class WarplaneCharacteristics
    {
        public int Crew { get; set; }

        public double Length { get; set; }
        public double Wingspan { get; set; } // 14m
        public double BackWingspan { get; set; } // 10.8 m
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
        public string WeaponDescription { get; set; }
        // Cannon 30 mm cannon built 9A1-4071K (upgraded GS-30-1, the rate of fire and recoil energy saved)

    }
}
