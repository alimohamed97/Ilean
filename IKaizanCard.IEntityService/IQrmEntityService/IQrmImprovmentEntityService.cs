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
    public interface IQrmImprovmentEntityService
    {
        Task<ActionResultDto> CreateQrmImprovments(RequestDto<QrmImprovmentDto> QrmImprovmentDto); Task<QrmImprovmentDto> GetQrmImprovmentByID(RequestDto<IdentityDto<int>> QrmImprovmentsId);
        Task<PageList<ImprovmnetListDto>> GetAllImprovmentList(ImprovmentSearchDto filterationDto); Task<ActionResultDto> UpdateQrmImprovment(RequestDto<QrmImprovmentDto> QrmImprovmentDto);
        Task<ActionResultDto> DeleteQrmImprovment(RequestDto<IdentityDto<int>> _ideintity);
    }
}
