using Data.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entity.Entities.Qrm
{
    public class QrmHeader : BaseEntity
    {
        [Key]
        public int QrmHeaderId { get; set; }
        public int QrmServiceNameId { get; set; }
        public int QrmCategoreyServiceId { get; set; }

        public int CreatedByUserId { get; set; }

        //navigation

        public virtual QrmImprovment QrmImprovment { get; set; }


    }
}
