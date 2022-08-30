using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities
{
    public class InspectionTeamSafetyStandard
    {
        [Key]
        public int SafetyStandardId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [ForeignKey("SafetyStandard")]
        public int WorkStandardId { get; set; }
        public virtual User StaffNumber { get; set; }
        public virtual SafetyStandard SafetyStandard { get; set; }
    }
}
