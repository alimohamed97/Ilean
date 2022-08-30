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
    public interface IKaizenCardAppService
    {

        Task<ResponseDto<PageList<KaizenCardListDto>>> GetAllKaizenCard(RequestDto<KaizenCardSearchDto> request);
        Task<ResponseDto<KaizenCardListDto>> GetKaizenCardDtoById(RequestDto<IdentityDto<int>> request);
        Task<ResponseDto<EmptyResponseDto>> CreateKarzianCard(RequestDto<KaizenCardDto> request);
        Task<ResponseDto<EmptyResponseDto>> DeleteKaizanCard(RequestDto<IdentityDto<int>> request);
        Task<ResponseDto<EmptyResponseDto>> UpdateKarzianCard(RequestDto<KaizenCardDto> request);
        Task<ResponseDto<PageList<KaizenCardListDto>>> SearchKaizenCardByNameAndStuffNumber(RequestDto<IdentityDto<string>> request);

    }
}
