using System;
using System.Collections.Generic;
using System.Text;

namespace IWebToken.JWT
{
   public interface ITokenInfo
    {
        string GetTokenData(Core.Enum.Security.TokenInfo tokenInfo, System.Security.Claims.ClaimsPrincipal user);
    }
}
