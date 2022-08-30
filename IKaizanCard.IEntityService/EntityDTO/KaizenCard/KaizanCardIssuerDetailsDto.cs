using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO
{
    public class KaizanCardIssuerDetailsDto
    {
        public int KaizanCardIssuerDetailsID { get; set; }
        public int StuffNumber { get; set; }
        public int IssuedByUserId { get; set; }
        public DateTime ValidateUntil { get; set; }
        public int ValidatedByUserID { get; set; }

        public int ChampionUserID { get; set; }



    }
}
