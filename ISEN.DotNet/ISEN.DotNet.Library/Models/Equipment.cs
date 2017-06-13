using System;
using System.Collections.Generic;

namespace ISEN.DotNet.Library.Models
{
    public class Equipment : BaseEntity
    {
        public string Type { get; set;}
        public int MaxProduction { get; set; }
        public List<Statement> StatementCollection = new List<Statement>();
    }
}
