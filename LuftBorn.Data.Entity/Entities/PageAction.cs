using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Entities
{
    public class PageAction : Base.BaseEntity
    {
        [Key]
        public int PageActionId { get; set; }

        [ForeignKey("PageId")]
        public virtual Page Page { get; set; }
        public int PageId { get; set; }

        public long ActionTypeId { get; set; }

        
    }
}
