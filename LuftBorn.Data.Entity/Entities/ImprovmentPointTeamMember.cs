using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entity.Entities
{
    public class ImprovmentPointTeamMember
    {
        public int TeamMemberImprovementTeamId { get; set; }
        public int ImprovementPointId { get; set; }
        public int UserId { get; set; }
    }
}
