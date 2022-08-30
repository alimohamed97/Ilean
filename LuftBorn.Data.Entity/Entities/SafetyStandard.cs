using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities
{
    public class SafetyStandard
    {
        [Key]
        public int SafetyStandardId { get; set; }
        public string SafetyStandardName { get; set; }
        [ForeignKey("User")]
        public int StaffNumber { get; set; }
        public int InspectionTypeSafetyId { get; set; }
        public virtual User StaffNum { get; set; }


    }
}
