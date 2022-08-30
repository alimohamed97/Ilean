using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity.Entities
{
    public class ImpoventAreaType
    {
        [Key]
        public int ImoprovmentID { get; set; }
        public string Title { get; set; }

    }
}
