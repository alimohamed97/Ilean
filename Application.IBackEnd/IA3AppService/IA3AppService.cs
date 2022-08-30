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
    public interface IA3AppService
    {
        Task<ResponseDto<EmptyResponseDto>> CreateA3(RequestDto<A3Dto> request);
        Task<ResponseDto<EmptyResponseDto>> CreateA32(RequestDto<A3SetDto> request);
        Task<ResponseDto<EmptyResponseDto>> UpdateA3(RequestDto<A3Dto> request);
        Task<ResponseDto<EmptyResponseDto>> DeleteA3(RequestDto<IdentityDto<int>> request);
        Task<ResponseDto<A3RowDto>> A3ById(RequestDto<IdentityDto<int>> request);
        Task<ResponseDto<PageList<A3ListDto>>> GetAllA3(RequestDto<A3SearchDto> request);
        Task<ResponseDto<EmptyResponseDto>> UpdateUploadsFiles(RequestDto<UploadFileDto> request);



    }
}
