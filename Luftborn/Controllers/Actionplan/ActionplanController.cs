using Application.IBackEnd;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Lean.Data.IEntityService.DTO;
using Lean.Data.IEntityService.EntityDTO;
using IWebToken.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Core.Enum.Security;
using System.Threading.Tasks;

namespace Lean.Controllers.Actionplan
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class ActionplanController : ControllerBase
    {
        private ITokenInfo TokenInfo { get; }
        IActionplanAppService ActionplanAppService { get; }
        public ActionplanController(ITokenInfo _TokenInfo, IActionplanAppService _ActionplanAppService)
        {
            TokenInfo = _TokenInfo;
            ActionplanAppService = _ActionplanAppService;
          
        }
        [HttpPost]
        public async Task<IActionResult> GetActionsPlanByID(RequestDto<IdentityDto<int>> request)
        {
            return Ok(await ActionplanAppService.GetActionsPlanByID(request));
        }
        [HttpPost]
        public async Task<IActionResult> CreateActionsPlan(RequestDto<A3ActionsPlanDto> request)
        {
            request.UserId = int.Parse(TokenInfo.GetTokenData(Core.Enum.Security.TokenInfo.UserId, User));
            return Ok(await ActionplanAppService.CreateActionsPlan(request));
        }
        [HttpPost]
        public async Task<IActionResult> GetAllActionsPlan(RequestDto<IdentityDto<int>> request)
        {
            return Ok(await ActionplanAppService.GetAllActionsPlan(request));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteActionsPlan(RequestDto<IdentityDto<int>> requestid)
        {
            return Ok(await ActionplanAppService.DeleteActionsPlan(requestid));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateActionsPlan(RequestDto<A3ActionsPlanDto> request)
        {
            request.UserId = int.Parse(TokenInfo.GetTokenData(Core.Enum.Security.TokenInfo.UserId, User));
            return Ok(await ActionplanAppService.UpdateActionsPlan(request));
        }
        
        

    }
}
