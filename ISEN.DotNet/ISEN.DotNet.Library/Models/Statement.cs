using System;

namespace ISEN.DotNet.Library.Models
{
    public class Statement : BaseEntity
    {
        public DateTime Date { get; set; }
        public double Production { get; set; }
        public double Consommation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double OverProduction { get; set; }
        public Equipment Equipment {get; set; }
        public int? EquipmentId { get; set; }
        public string Location => $"{Latitude} - {Longitude}";
        public double Rendement => Math.Round((Production / (double)Equipment.MaxProduction )* 100);
    }
}
