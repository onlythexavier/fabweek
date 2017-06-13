using System;

namespace ISEN.DotNet.Library.Models
{
    public class Owner : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public override string Display => $"{FirstName} {LastName}";
        public string Location => $"{City}, {Country.ToUpper()}";
        public override string ToString() => $"Nom={FirstName}|{LastName}";
    }
}
