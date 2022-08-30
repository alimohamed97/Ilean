using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity.Entities.KaizenCard
{
    public class FinanceVertification
    {
        [Key]
        public int FinanceVertificationID { get; set; }
        public string Name { get; set; }
    }
}
