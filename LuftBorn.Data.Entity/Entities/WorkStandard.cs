using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities
{
    public class WorkStandard
    {
        [Key]
        public int WorkStandardId { get; set; }
        public string WorkStandardName { get; set; }
        
        [ForeignKey("User")]
        public int StaffNumber { get; set; }
        [ForeignKey("InspectionType")]
        public int InspectionTypeId { get; set; }
        public DateTime InspectionDate { get; set; }
        public virtual User StaffNum{ get; set; }
      //  public int TeamLeadUserId { get; set; }
        //public virtual ICollection<> ActionsPlans { get; set; }
    }
}
