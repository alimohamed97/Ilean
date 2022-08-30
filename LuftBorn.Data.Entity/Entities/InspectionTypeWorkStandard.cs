using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity.Entities
{
    public class InspectionTypeWorkStandard
    {
        [Key]
        public  int InspectionTypeId { get; set; }
        public string InspectionTypeName { get; set; }

    }
}
