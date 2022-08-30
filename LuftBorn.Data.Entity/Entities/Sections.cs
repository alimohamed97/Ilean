using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity.Entities
{
    public class Sections 
    {
        [Key]
        public int SectionID { get; set; }
        public string SectionName { get; set; }

        public virtual ICollection< User> User { get; set; }
    }
}
