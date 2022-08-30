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
    public interface IKaizenCardService
    {
        Task<ActionResultDto> CreateKarzianCard(RequestDto<KaizenCardDto> karzianCardDto);
        
        Task<PageList<KaizenCardListDto>> RetrieveAllKaizenCard(KaizenCardSearchDto filterationDto, string UrlParam);
        Task<KaizenCardListDto> GetKaizanCardByID(RequestDto<IdentityDto<int>> _identity);        Task<ActionResultDto> UpdateCreateKarzianCard(RequestDto<KaizenCardDto> karzianCardDto);
        Task<ActionResultDto> DeleteKaizanCard(RequestDto<IdentityDto<int>> _identity);
        Task<PageList<KaizenCardListDto>> SearchKaizenCardByNameAndStuffNumber(RequestDto<IdentityDto<string>> _freetext);
    }
}
