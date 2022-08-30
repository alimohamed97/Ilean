using Core.Enum;
using System;
using System.ComponentModel.DataAnnotations;


namespace Data.Entity.Base
{
    public class BaseEntity
    {
        internal BaseEntity()
        {
            DeleteStatus =  (int)Common.DeleteStatus.NotDeleted;
        }

        [Required]
        public int DeleteStatus  { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
