using System;
using System.Collections.Generic;
using System.Text;

namespace Lean.Data.IEntityService.EntityDTO.A3
{
    public class TeamMemberDto
    {
  
        public int TeamMembersId { get; set; }
        public string MemberName { get; set; }

        public int UserId { get; set; }
      
        public int A3HeaderId { get; set; }
     
    }
}
