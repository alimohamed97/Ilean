using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.EntityDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Data.IEntityService
{
    public interface IKaizanCardEntityDetailService
    {
        Task<ActionResultDto> CreateKaizanCardDetail(RequestDto<KaizenCardDetailsDto> KaizanCardDetailsDto);
        Task<KaizenCardDetailsDto> GetKaizanCardDetailByID(RequestDto<IdentityDto<int>> CardDetailsID);
        Task<PageList<KaizenCardDetailsDto>> GetAllKaizenCardDetailsList();
        Task<ActionResultDto> UpdateKaizanCardDetail(RequestDto<KaizenCardDetailsDto> KaizenCardDetailsDto);
        Task<ActionResultDto> DeleteKaizanCardDetail(RequestDto<KaizenCardDetailsDto> KaizenCardDetailsDto);


    }
}
