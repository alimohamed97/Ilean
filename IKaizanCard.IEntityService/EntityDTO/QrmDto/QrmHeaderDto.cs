using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO.QrmDto
{
    public class QrmHeaderDto
    {
        public int QrmHeaderId { get; set; }
        public int QrmServiceNameId { get; set; }
        public int QrmCategoreyServiceId { get; set; }

        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
