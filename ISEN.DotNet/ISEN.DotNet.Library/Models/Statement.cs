using System;

namespace ISEN.DotNet.Library.Models
{
    public class Statement : BaseEntity
    {
        public DateTime Date { get; set; }
        public double Production { get; set; }
        public double Consommation { get; set; }
        public Equipment Equipment {get; set; }
        public int? EquipmentId { get; set; } 
    }
}
