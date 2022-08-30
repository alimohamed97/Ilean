using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity.Entities
{
    public class Currency 
    {
        [Key]
        public int CurrencyId { get; set; }
        public string CurrencyDesc { get; set; }
        public string CurrencyCode { get; set; }

    }
}
