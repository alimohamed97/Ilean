using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.EntityDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IBackEnd
{
    public interface IKaizanCardHeaderAppService
    {
        Task<ResponseDto<EmptyResponseDto>> CreateKaizanCardHeader(RequestDto<KaizenCardHeaderDto> request);
        Task<ResponseDto<EmptyResponseDto>> UpdateKaizanCardHeader(RequestDto<KaizenCardHeaderDto> request);

        Task<ResponseDto<KaizenCardHeaderDto>> GetKaizenCardHeaderById(RequestDto<IdentityDto<int>> request);
        Task<ResponseDto<EmptyResponseDto>> DeleteKaizenCardHeader(RequestDto<KaizenCardHeaderDto> request);

    }
}
