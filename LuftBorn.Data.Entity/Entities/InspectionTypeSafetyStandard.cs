using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity.Entities
{
    public class InspectionTypeSafetyStandard
    {
        [Key]
        public  int InspectionTypeId { get; set; }
        public string InspectionTypeName { get; set; }

    }
}
