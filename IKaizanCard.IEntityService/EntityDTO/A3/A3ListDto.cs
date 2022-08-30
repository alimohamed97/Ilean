using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO
{
    public class A3ListDto
    {
        public string Title { get; set; }
        public int TeamLeadUserId { get; set; }
        public int TeamCoachId { get; set; }
        public string Process { get; set; }
        public int StatuesId { get; set; }
        public long A3Number { get; set; }
        public string TeamCoachName { get; set; }
        public string TeamLeadName { get; set; }
        public string StatuesName { get; set; }
        public int A3headerId { get; set; }
        public int DeleteStatus { get; set; }
    }
}
