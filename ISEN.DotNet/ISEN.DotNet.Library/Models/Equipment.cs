using System;

namespace ISEN.DotNet.Library.Models
{
    public class Equipment : BaseEntity
    {
        public int IdOwner { get; set; }
        public enum Type { SolarPanel, WindTurbine, HydroElectric}
        public int MaxProduction { get; set; }
    }
}
