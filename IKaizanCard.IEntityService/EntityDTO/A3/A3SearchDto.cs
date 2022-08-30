using Core.Common.Dto.Action;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO
{
    public class A3SearchDto
    {
        public PagingModel PagingModel { get; set; }
        public string Title { get; set; }
        public int StatuesId { get; set; }
        public long A3Number { get; set; }
        public int TeamLeadUserId { get; set; }
        public int TeamCoachId { get; set; }
    }
}
