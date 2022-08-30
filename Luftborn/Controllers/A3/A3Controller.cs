using Application.IBackEnd;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using IWebToken.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Core.Enum.Security;
using System.Threading.Tasks;
using System.Collections.Generic;
using Lean.Data.IEntityService.DTO;
using Lean.Data.IEntityService.EntityDTO;

namespace Lean.Controllers.A3
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
 
    public class A3Controller : ControllerBase
    {
        private ITokenInfo TokenInfo { get; }
        IA3AppService A3AppService { get; }
        IActionplanAppService actionAppService { get; }
        public A3Controller(ITokenInfo _TokenInfo, IA3AppService _A3AppService, IActionplanAppService _actionAppService)
        {
            TokenInfo = _TokenInfo;
            A3AppService = _A3AppService;
            actionAppService = _actionAppService;
        }
        [HttpPost]
        public async Task<IActionResult> GetA3ById(RequestDto<IdentityDto<int>> request)
        {
            return Ok(await A3AppService.A3ById(request));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewA32(RequestDto<A3SetDto> request)
        {
           request.UserId = int.Parse(TokenInfo.GetTokenData(Core.Enum.Security.TokenInfo.UserId, User));
            return Ok(await A3AppService.CreateA32(request));
        }


        [HttpPost]
        public async Task<IActionResult> AddNewA3(RequestDto<A3Dto> A3Dto)
        {
            A3Dto.UserId = int.Parse(TokenInfo.GetTokenData(Core.Enum.Security.TokenInfo.UserId, User));
            return Ok(await A3AppService.CreateA3(A3Dto));
        }
        [HttpPost]
        public async Task<IActionResult> GetAllA3(RequestDto<A3SearchDto> request)
        {
            return Ok(await A3AppService.GetAllA3(request));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteA3(RequestDto<IdentityDto<int>> request)
        {
            return Ok(await A3AppService.DeleteA3(request));
        }


        [HttpPost]
        public async Task<IActionResult> UpdateA3(RequestDto<A3Dto> request)
        {
            request.UserId = int.Parse(TokenInfo.GetTokenData(Core.Enum.Security.TokenInfo.UserId, User));
            return Ok(await A3AppService.UpdateA3(request));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUploadsFiles(RequestDto<UploadFileDto> request)
        {
            request.UserId = int.Parse(TokenInfo.GetTokenData(Core.Enum.Security.TokenInfo.UserId, User));
            return Ok(await A3AppService.UpdateUploadsFiles(request));
        }

    }
  
}
