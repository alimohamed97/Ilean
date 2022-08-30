using IWebToken.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace IWebToken.JWT
{
    public interface ITokenGenerator
    {
        string CreateToken(List<UserClaim> userClaims, string audience, string issuer);
    }
}
