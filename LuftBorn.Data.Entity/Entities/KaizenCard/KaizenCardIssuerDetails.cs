using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities
{
    public class KaizenCardIssuerDetails 
    {
        [Key]
        public int KaizanCardIssuerDetailsID { get; set; }

        [ForeignKey("KaizenCardHeader")]
        public int KaizanCardHeaderID { get; set; }
        public virtual KaizenCardHeader KaizenCardHeader { get; set; }
        public long StuffNumber { get; set; }

        [ForeignKey("User")]
        public int IssuedByUserId{ get; set; }

        [ForeignKey("TeamCoachUser")]
        public int TeamCoachId { get; set; }

        [ForeignKey("ValidatedByUsers")]
        public int ValidatedByUserID { get; set; }

        [ForeignKey("ChampionUsers")]
        public int ChampionUserID { get; set; }

        public int DepartmentID { get; set; }

        public DateTime IssuedDate { get; set; }
        public DateTime ValidUntilDate { get; set; }

        public virtual User User { get; set; }
        public virtual User TeamCoachUser { get; set; }
        public virtual User ChampionUsers { get; set; }
        public virtual User ValidatedByUsers { get; set; }

        

    }
}
