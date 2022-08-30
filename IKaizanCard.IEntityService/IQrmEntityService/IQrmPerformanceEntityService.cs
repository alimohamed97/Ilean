using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.EntityDTO.QrmDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Data.IEntityService.IQrmEntityService
{
    public interface IQrmPerformanceEntityService
    {

        Task<ActionResultDto> CreateQrmPerformance(RequestDto<QrmPerformanceDto> QrmPerformanceDto); Task<QrmPerformanceDto> GetQrmPerformancetByID(RequestDto<IdentityDto<int>> QrmPerformanceID);
        Task<PageList<ImprovmnetListDto>> GetAllImprovmentList(ImprovmentSearchDto filterationDto); Task<ActionResultDto> UpdateQrmImprovment(RequestDto<QrmPerformanceDto> QrmPerformanceDto);
        Task<ActionResultDto> DeleteQrmImprovment(RequestDto<IdentityDto<int>> _ideintity);
    }
}
