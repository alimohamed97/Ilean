using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Data.Entity.Entities
{
    public class UnitArea 
    {
        [Key]
        public int UnitAreaID { get; set; }
        public string UnitAreaName { get; set; }


    }
}
