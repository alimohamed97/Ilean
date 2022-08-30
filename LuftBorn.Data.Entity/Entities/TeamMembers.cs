using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities
{
    public class TeamMembers
    {
        [Key]
        public int TeamMembersId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("A3header")]
        public int A3HeaderId { get; set; }
        public virtual A3header A3header { get; set; }
        public virtual User User { get; set; }

    }
}
