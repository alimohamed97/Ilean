using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity.Entities
{
    public partial class Statues 
    {
        [Key]
        public int StatuesId { get; set; }
        public string StatuesName { get; set; }

        //public virtual ICollection<ActionsPlan> ActionsPlans { get; set; }

    }
}
