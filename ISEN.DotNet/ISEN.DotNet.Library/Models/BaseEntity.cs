using System;

namespace ISEN.DotNet.Library.Models
{
    public abstract class BaseEntity
    {
        public int Id { get;set; }
        public string Name { get;set; }

        public bool IsNew => Id <= 0;
        public virtual string Display => Name;
        public override string ToString() => $"Id={Id}|{Display}";
    }
}
