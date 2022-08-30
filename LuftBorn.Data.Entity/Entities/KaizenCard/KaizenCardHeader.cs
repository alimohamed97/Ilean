using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities
{
    public class KaizenCardHeader :BaseEntity
    {
        [Key]
        public int KaizanCardHeaderID { get; set; }
        public string Theme { get; set; }
        public int Number { get; set; }
        public int UnitAreaID { get; set; }
        public bool IsDraft { get; set; }

        [ForeignKey("User")]
        public int CreatedByUserID { get; set; }
        public string UnitAreaTital { get; set; }

        public virtual UnitArea UnitArea { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<KaizenCardIssuerDetails> KaizenCardIssuerDetails { get; set; }
        public virtual ICollection<KaizenCardDetails> KaizenCardDetails { get; set; }
        public virtual ICollection<KaizenCardImprovment> KaizenCardImprovment { get; set; }



    }
}
