using Application.IBackEnd;
using IWebToken.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Lean.Controllers.GenericLookups
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenericLookupsController : ControllerBase
    {
        private ITokenInfo TokenInfo { get; }
        private IAppLookupAppService IAppLookupAppService { get; }

        public GenericLookupsController(IAppLookupAppService _IAppLookupAppService, ITokenInfo _TokenInfo)
        {
            IAppLookupAppService = _IAppLookupAppService;

            TokenInfo = _TokenInfo;

        }

        #region DDL

        [HttpPost]
        public async Task<IActionResult> RetrieveUnitAreaDropDownList()
        {
            return Ok(await IAppLookupAppService.UnitAreaDropDownList());
        }

        [HttpPost]
        public async Task<IActionResult> RetrieveUsersDropDownList()
        {
            return Ok(await IAppLookupAppService.UsersDropDownList());
        }

        [HttpPost]
        public async Task<IActionResult> CurrencyDropDownList()
        {
            return Ok(await IAppLookupAppService.CurrencyDropDownList());
        }

        [HttpPost]
        public async Task<IActionResult> StatuesDropDownList()
        {
            return Ok(await IAppLookupAppService.StatuesDropDownList());
        }

        [HttpPost]
        public async Task<IActionResult> ImpoventAreaTypeDropDownList()
        {
            return Ok(await IAppLookupAppService.ImpoventAreaTypeDropDownList());
        }

        [HttpPost]
        public async Task<IActionResult> DepartmentDropDownList()
        {
            return Ok(await IAppLookupAppService.DepartmentDropDownList());
        }

        [HttpPost]
        public async Task<IActionResult> SectionsDropDownList()
        {
            return Ok(await IAppLookupAppService.SectionDropDownList());
        }


        [HttpPost]
        public async Task<IActionResult> TeamCoachDropDownList()
        {
            return Ok(await IAppLookupAppService.TeamCoachDropDownList());
        }




        [HttpPost]
        public async Task<IActionResult> FinanceVertificationStatues()
        {
            return Ok(await IAppLookupAppService.FinanceVertificationStatues());
        }





        [HttpPost]
        public async Task<IActionResult> TeamMeambersDropDownList()
        {
            return Ok(await IAppLookupAppService.TeamMeambersDropDownList());
        }



        #endregion

    }
}
