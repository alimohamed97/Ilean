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
    public interface IKaizanCardDetailAppService
    {
        Task<ResponseDto<EmptyResponseDto>> CreateKaizanCardDetail(RequestDto<KaizenCardDetailsDto> request);
        Task<ResponseDto<EmptyResponseDto>> UpdateKaizanCardDetail(RequestDto<KaizenCardDetailsDto> request);
        Task<ResponseDto<EmptyResponseDto>> DeleteOraganization(RequestDto<KaizenCardDetailsDto> request);
        Task<ResponseDto<KaizenCardDetailsDto>> KaizanCardDetailById(RequestDto<IdentityDto<int>> request);

    }
}
