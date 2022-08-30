using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity.Entities.A3
{
   public  class ActionPlanStatues
    {
        [Key]
        public int ActionPlanStatuesID { get; set; }
        public string ActionPlanStatuesTital { get; set; }

    }
}
