using Data.Entity.Base;
using Data.Entity.Entities.A3;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Entities
{
    public partial class ActionsPlan:BaseEntity
    {
        [Key]
        public int ActionsPlanId { get; set; }
        public string Action { get; set; }
        [ForeignKey("User")]
        public int UserIdstuffNo { get; set; }
       // public string Name { get; set; }
        public DateTime DueData { get; set; }
        [ForeignKey("ActionPlanStatues")]
        public int ActionPlanStatuesID { get; set; }
        [ForeignKey("A3header")]
        public int A3headerId { get; set; }

        
        public virtual A3header A3header { get; set; }
        public virtual ActionPlanStatues ActionPlanStatues { get; set; }
        public virtual User User { get; set; }
      
    }
}
