using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities
{
    public class KaizenCardImprovment 
    {
        [Key]
        public int KaizenCardImprovmentID { get; set; }

        [ForeignKey("KaizenCardHeader")]
        public int KaizanCardHeaderID { get; set; }

        [ForeignKey("ImpoventAreaType")]
        public int ImprovmentID { get; set; }
        public virtual ImpoventAreaType ImpoventAreaType { get; set; }

        public virtual KaizenCardHeader KaizenCardHeader { get; set; }
    }
}
