using System.Collections.Generic;

namespace ISEN.DotNet.Library.Models
{
    public class Equipment : BaseEntity
    {
        public Owner Owner { get; set; }
        public int? OwnerId { get; set; }
        public string Type { get; set;}
        public double Latitude { get; set;}
        public double Longitude { get; set;}
        public double MaxProduction { get; set; }
        public string IdObject { get; set; }
        public string Location => $"{Latitude} - {Longitude}";
        public List<Statement> StatementCollection = new List<Statement>();

        public void AddStatement(Statement statement)
        {
            StatementCollection.Add(statement);
            statement.Equipment = this;
        }
    }
}
