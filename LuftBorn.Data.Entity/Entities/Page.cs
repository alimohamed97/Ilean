using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Entities
{
    public class Page : Base.BaseEntity
    {
        [Key]
        public int PageId { get; set; }

        [ForeignKey("ParentPageId")]
        public virtual Page ParentPage { get; set; }
        public int? ParentPageId { get; set; }

        public string PageUrl { get; set; }
        public int MenuOrder { get; set; }
        public string PageIcon { get; set; }

        public virtual ICollection<PageLocalization> PageLocalization { get; set; }
    }
}
