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
    public interface IQrmTeamEntityService
    {
        Task<ActionResultDto> CreateQrmTeam(RequestDto<QrmTeamDto> QrmTeamDto);
        Task<QrmTeamDto> GetQrmQrmTeamByID(RequestDto<IdentityDto<int>> QrmTeamId);
        Task<PageList<ImprovmnetListDto>> GetAllImprovmentList(ImprovmentSearchDto filterationDto); Task<ActionResultDto> UpdateQrmTeam(RequestDto<QrmTeamDto> QrmTeamDto);
        Task<ActionResultDto> DeleteQrmTeam(RequestDto<IdentityDto<int>> _ideintity);
    }
}
