using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities
{
    public class InspectionTeamWorkStandard
    {
        [Key]
        public int InspectionTeamWorkId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("WorkStandard")]
        public int WorkStandardId { get; set; }
        public virtual User StaffNumber { get; set; }
        public virtual WorkStandard WorkStandard { get; set; }
    }
}
