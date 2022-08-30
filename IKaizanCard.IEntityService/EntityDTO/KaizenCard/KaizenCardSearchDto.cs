using Core.Common.Dto.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO
{
    public class KaizenCardSearchDto
    {
        public PagingModel PagingModel { get; set; }
        public string Theme { get; set; }
        public string StuffNumber { get; set; }
        public int IssuedbyUserid { get; set; }
        public int UnitAreaid { get; set; }
        public int ValidatedbyUserid { get; set; }
        public int ChampionUserid { get; set; }
        public string ValidUntildate { get; set; }
        public string Issueddate { get; set; }
        public int StatuesId { get; set; }
        public string SearchText { get; set; }

        public string UnitAreaName { get; set; }


    }


}
