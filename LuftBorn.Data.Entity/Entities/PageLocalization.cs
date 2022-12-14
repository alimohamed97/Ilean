using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Entities
{
    public class PageLocalization : Base.BaseEntity
    {
        [Key]
        public int PageLocalizationId { get; set; }

        [ForeignKey("PageId")]
        public virtual Page Page { get; set; }
        public int PageId { get; set; }


        public string PageName { get; set; }
    }
}
