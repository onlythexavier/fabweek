using System;
using System.Collections.Generic;

namespace ISEN.DotNet.Library.Models
{
    public class Equipment : BaseEntity
    {
        public Owner Owner { get; set; }
        public int? OwnerId { get; set; }
        public string Type { get; set;}
        public int MaxProduction { get; set; }
        public string IdObject { get; set; }
        public List<Statement> StatementCollection = new List<Statement>();

        public void AddStatement(Statement statement)
        {
            StatementCollection.Add(statement);
            statement.Equipment = this;
        }
    }
}
