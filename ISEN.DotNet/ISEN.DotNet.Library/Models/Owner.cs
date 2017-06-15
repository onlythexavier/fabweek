using System;
using System.Collections.Generic;

namespace ISEN.DotNet.Library.Models
{
    public class Owner : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? AccountId { get; set; }
        public AccountUser Account { get; set; }
        public override string Display => $"{FirstName} {LastName.ToUpper()}";
        public string Location => $"{City}, {Country.ToUpper()}";
        public override string ToString() => $"{FirstName} {LastName.ToUpper()}";

        public List<Equipment> EquipmentCollection { get; set; } = new List<Equipment>();

        public void AddEquipment(Equipment equipment)
        {
            EquipmentCollection.Add(equipment);
            equipment.Owner = this;
        }
    }
}