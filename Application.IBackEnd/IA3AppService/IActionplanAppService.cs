using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.DTO;
using Lean.Data.IEntityService.EntityDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IBackEnd
{
    public interface IActionplanAppService
    {
        Task<ResponseDto<EmptyResponseDto>> CreateActionsPlan(RequestDto<A3ActionsPlanDto> request);
        Task<ResponseDto<A3ActionsPlanDto>> GetActionsPlanByID(RequestDto<IdentityDto<int>> request);
        Task<ResponseDto<PageList<A3ActionsPlanDtoList>>> GetAllActionsPlan(RequestDto<IdentityDto<int>> request);
        Task<ResponseDto<EmptyResponseDto>> UpdateActionsPlan(RequestDto<A3ActionsPlanDto> request);
       Task<ResponseDto<EmptyResponseDto>> DeleteActionsPlan(RequestDto<IdentityDto<int>> request);



    }
}