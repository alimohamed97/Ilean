using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.DTO;
using Lean.Data.IEntityService.EntityDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Lean.Data.IEntityService
{
    public interface IActionEntityService
    {
        Task<ActionResultDto> CreateAction(RequestDto<A3ActionsPlanDto> ActionDto);
        Task<A3ActionsPlanDto> GetActionByID(RequestDto<IdentityDto<int>> ActionID);

        Task<PageList<A3ActionsPlanDto>> GetAllAction();
        Task<ActionResultDto> UpdateAction(RequestDto<A3ActionsPlanDto> ActionDto);
        Task<ActionResultDto> DeleteAction(RequestDto<A3ActionsPlanDto> ActionDto);
    }
}
