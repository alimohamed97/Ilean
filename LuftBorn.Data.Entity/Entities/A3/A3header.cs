using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Entities
{
    public class A3header:BaseEntity
    {

        [Key]
        public int A3headerId { get; set; }
        public long A3Number { get; set; }

        [ForeignKey("TeamLeadUser")]
        public int TeamLeadUserId { get; set; }

        [ForeignKey("TeamCoachUser")]
        public int TeamCoachId { get; set; }

        [ForeignKey("User")]
        public int IssuedByUserId { get; set; }
        public string Title { get; set; }
        public string Process { get; set; }
        [ForeignKey("Statues")]
        public int StatuesId { get; set; }
        public DateTime IssuedDate { get; set; }      
        public int StuffNumber { get; set; }

        public virtual User User { get; set; }
        public virtual User TeamLeadUser { get; set; }
        public virtual User TeamCoachUser { get; set; }
        public virtual Statues Statues { get; set; }
        public virtual ICollection<TeamMembers> TeamMembers { get; set; }
        public virtual ICollection<A3details> A3details { get; set; }
        public virtual ICollection<ActionsPlan> ActionsPlans { get; set; }
    }
}
