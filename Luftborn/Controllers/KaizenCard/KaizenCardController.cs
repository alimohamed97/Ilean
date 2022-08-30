using Application.IBackEnd;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using IWebToken.JWT;
using Lean.Data.IEntityService.EntityDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lean.Controllers.KaizenCard
{

    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class KaizenCardController : Controller
    {
        private ITokenInfo TokenInfo { get; }
        IKaizenCardAppService KaizenCardAppService { get; }
        IKaizanCardHeaderAppService KaizanCardEntityHeaderAppService { get; }
        public KaizenCardController(ITokenInfo _TokenInfo, IKaizenCardAppService _KaizenCardAppService,
            IKaizanCardHeaderAppService _KaizanCardEntityHeaderAppService)
        {
            TokenInfo = _TokenInfo;
            KaizenCardAppService = _KaizenCardAppService;
            KaizanCardEntityHeaderAppService = _KaizanCardEntityHeaderAppService;
        }

        [HttpPost]
        public async Task<IActionResult> GetKaizenCardDtoById(RequestDto<IdentityDto<int>> request)
        {
            return Ok(await KaizenCardAppService.GetKaizenCardDtoById(request));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteKaizanCard(RequestDto<IdentityDto<int>> request)
        {
            return Ok(await KaizenCardAppService.DeleteKaizanCard(request));
        }


        [HttpPost]
        public async Task<IActionResult> AddNewKaizenCardHeader(RequestDto<KaizenCardHeaderDto> request)
        {
            //request.UserId = int.Parse(TokenInfo.GetTokenData(Core.Enum.Security.TokenInfo.UserId, User));
            return Ok(await KaizanCardEntityHeaderAppService.CreateKaizanCardHeader(request));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewKaizenCard(RequestDto<KaizenCardDto> request)
        {
           request.UserId = int.Parse(TokenInfo.GetTokenData(Core.Enum.Security.TokenInfo.UserId, User));
          return Ok(await KaizenCardAppService.CreateKarzianCard(request));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateKaizenCard(RequestDto<KaizenCardDto> request)
        {
            request.UserId = int.Parse(TokenInfo.GetTokenData(Core.Enum.Security.TokenInfo.UserId, User));
            return Ok(await KaizenCardAppService.UpdateKarzianCard(request));
        }

        [HttpPost]
        public async Task<IActionResult> GetAllKaizenCard(RequestDto<KaizenCardSearchDto> request)
        {
            return Ok(await KaizenCardAppService.GetAllKaizenCard(request));
        }

        [HttpPost]
        public async Task<IActionResult> SearchKaizenCardByNameAndStuffNumber(RequestDto<IdentityDto<string>> request)
        {
            return Ok(await KaizenCardAppService.SearchKaizenCardByNameAndStuffNumber(request));
        }
    }
}
