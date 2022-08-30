using System;
using System.Collections.Generic;
using System.Text;

namespace IWebToken.DTO
{
   public class UserClaim
    {
        public Core.Enum.Security.TokenInfo Name { get; set; }
        public string Value { get; set; }

    }
}
