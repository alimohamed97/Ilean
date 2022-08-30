using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity.Entities
{
   public class Department 
    {
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
