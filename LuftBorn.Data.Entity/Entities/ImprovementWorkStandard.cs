using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity.Entities
{
    public class ImprovementWorkStandard
    {
        public int ImprovementWorkStandardId { get; set; }
        public string Describtion { get; set; }
        public int WorkStandardId { get; set; }
        public string Comment { get; set; }
        public DateTime Galender { get; set; }


    }
}
