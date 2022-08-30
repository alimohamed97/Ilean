
using Application.IBackEnd;
using Application.IBackEnd.IUserAppService;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using IWebToken.JWT;
using Lean.Data.IEntityService.DTO;
using Lean.Data.IEntityService.EntityDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lean.Controllers.Users
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        private ITokenInfo TokenInfo { get; }

        IUserAppService UserAppService { get; }
        public UsersController(ITokenInfo _TokenInfo, IUserAppService _UserAppService  )
        {
            TokenInfo = _TokenInfo;
            UserAppService = _UserAppService;
          
        }

        [HttpPost]
        public async Task<IActionResult> GetUserById(RequestDto<IdentityDto<int>> request)
        {
            return Ok(await UserAppService.GetUserById(request));
        }

        [HttpPost]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await UserAppService.GetAllUsers());
        }

        [HttpPost]
        public async Task<IActionResult> GetUserByStuffNumber(RequestDto<IdentityDto<long>> request)
        {
            return Ok(await UserAppService.GeUserByStuffNumber(request));
        }

    }
}
