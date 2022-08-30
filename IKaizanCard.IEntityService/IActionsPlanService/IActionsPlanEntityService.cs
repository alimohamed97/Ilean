using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.DTO;
using Lean.Data.IEntityService.EntityDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Data.IEntityService.IActionService
{
    public interface IActionsPlanEntityService
    {
        Task<ActionResultDto> CreateActionsPlan(RequestDto<A3ActionsPlanDto> ActionDto);
        Task<A3ActionsPlanDto> GetActionsPlanByID(RequestDto<IdentityDto<int>> ActionID);
        Task<PageList<A3ActionsPlanDtoList>> GetAllActionsPlan(RequestDto<IdentityDto<int>> request);
        Task<ActionResultDto> UpdateActionsPlan(RequestDto<A3ActionsPlanDto> ActionDto);  
        Task<ActionResultDto> DeleteActionPlan(RequestDto<IdentityDto<int>> _identity);
    } 
}
