using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.DTO;
using Lean.Data.IEntityService.EntityDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Data.IEntityService.IA3EntityService
{
    public interface IA3EntityService
    {
        Task<ActionResultDto> CreateA3(RequestDto<A3Dto> A3Dto);
        Task<ActionResultDto> CreateA32(RequestDto<A3SetDto> A3SetDto);
        Task<A3RowDto> GetA3ByID(RequestDto<IdentityDto<int>> A3ID);
        Task<ActionResultDto> UpdateUploadsFiles(RequestDto<UploadFileDto> _UploadFileDto);
        Task<PageList<A3ListDto>> GetAllA3(A3SearchDto filterationDto);
        Task<ActionResultDto> UpdateA3(RequestDto<A3Dto> A3Dto);
        Task<ActionResultDto> DeleteA3(RequestDto<IdentityDto<int>> _identity);

    }
}
