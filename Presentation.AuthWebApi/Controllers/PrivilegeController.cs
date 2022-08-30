using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

using Core.Common.Dto.Request;
using Data.Auth.EntityService.Dto.Privilege;

using Application.Auth.Application;
using IWebToken.JWT;

namespace TMS.Presentation.AuthApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PrivilegeController : ControllerBase
    {
        #region CTR
        private IPrivilegeAppService PrivilegeAppService { get; }
        private ITokenInfo TokenInfo { get; }

        public PrivilegeController(ITokenInfo tokenInfo, IPrivilegeAppService privilegeAppService)
        {
            PrivilegeAppService = privilegeAppService;
            TokenInfo = tokenInfo;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> GetCurrentUserViews(RequestDto<EmptyRequestDto> requestDto)
        {
            int.TryParse(TokenInfo.GetTokenData(Core.Enum.Security.TokenInfo.UserId, HttpContext.User), out int userId);
            return Ok(await PrivilegeAppService.GetSystemPagesByUserId(userId, requestDto.Language));
        }

        [HttpPost]
        public async Task<IActionResult> GetUserViewActions(RequestDto<UserPageActions> requestDto)
        {
            int.TryParse(TokenInfo.GetTokenData(Core.Enum.Security.TokenInfo.UserId, HttpContext.User), out int userId);
            return Ok(await PrivilegeAppService.GetUserPagePrivilege(userId, requestDto.RequestData.PageId));
        }
    }
}
