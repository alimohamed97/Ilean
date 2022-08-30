using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO
{
    public class KaizenCardHeaderDto
    {
        public int KaizanCardHeaderID { get; set; }
        public string Theme { get; set; }
        public int Number { get; set; }
        public int UnitAreaID { get; set; }

    }
}
