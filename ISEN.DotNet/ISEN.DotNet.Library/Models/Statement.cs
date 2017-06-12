using System;

namespace ISEN.DotNet.Library.Models
{
    public class Statement : Equipment
    {
        public DateTime Date { get; set; }
        public double Production { get; set; }
    }
}
