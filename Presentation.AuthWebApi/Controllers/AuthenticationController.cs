using IWebToken.JWT;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebToken.Setting;
using Core.Common.Dto.Response;
using Core.Common.Dto.Request;
using IWebToken.DTO;
using static Core.Enum.Security;
using static Core.Enum.Request;
using Application.Auth;
using Data.Auth.EntityService.Dto;

namespace TMS.Presentation.AuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthAppService AuthAppService { get; }
        private ITokenGenerator TokenGenerator { get; }
        private AuthSettings Setting { get; }

        public AuthenticationController(IAuthAppService authAppService ,ITokenGenerator tokenGenerator, AuthSettings authSetting)
        {
            AuthAppService = authAppService;
  
            TokenGenerator = tokenGenerator;
            Setting = authSetting;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(RequestDto<LoginDto> loginUserDto)
        {
            ResponseDto<LoginResponse> response = await AuthAppService.ValidateUserCredentials(loginUserDto);

            if (response.Result == ResultStatusEnum.Success)
            {
                List<UserClaim> userClaims = new List<UserClaim>
                {
                    new UserClaim
                    {
                        Name = TokenInfo.UserId, Value = response.ResponseData.UserId.ToString()
                    }
                };
                response.ResponseData.AuthToken = TokenGenerator.CreateToken(userClaims, Setting.Audiance, Setting.Issuer);
            }

            return Ok(response);
        }

      
    }
}