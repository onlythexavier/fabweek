using System;

namespace ISEN.DotNet.Library.Models
{
    public abstract class Owner : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? EquipmentId { get; set; }
        
        public override string ToString() => $"Nom={FirstName}|{LastName}";
    }
}
