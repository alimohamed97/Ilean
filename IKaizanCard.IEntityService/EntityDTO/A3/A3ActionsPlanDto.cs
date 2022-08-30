using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO
{
    public class A3ActionsPlanDto 
    {
        public string Action { get; set; }
        public int UserIdstuffNo { get; set; }
        public string Name { get; set; }
        public DateTime DueData { get; set; }
        public int ActionPlanStatuesID { get; set; }
        public int A3headerId { get; set; }
        public int DeleteStatus { get; set; }

    }

    public class A3ActionsPlanDtoList
    {
        public int ActionsPlanId { get; set; }
        public string Action { get; set; }
        public int UserIdstuffNo { get; set; }
        public string Name { get; set; }
        public DateTime DueData { get; set; }
        public int ActionPlanStatuesID { get; set; }
        public int A3headerId { get; set; }
        public int DeleteStatus { get; set; }
        public string StatuesName { get; set; }
        public long StuffNumber { get; set; }

    }
}
