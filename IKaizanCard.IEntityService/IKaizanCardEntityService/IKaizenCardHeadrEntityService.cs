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
    public interface IKaizenCardHeadrEntityService
    {
        Task<ActionResultDto> CreateKarzianCardHeader(RequestDto<KaizenCardHeaderDto> KaizenCardHeaderDto);
        Task<KaizenCardHeaderDto> GetKaizanCardHeaderByID(RequestDto<IdentityDto<int>> CardDetailsID);
        Task<PageList<KaizenCardHeaderDto>> GetAllKaizenCardHeaderList();
        Task<ActionResultDto> UpdateKaizanCardHeader(RequestDto<KaizenCardHeaderDto> kaizanCardDto);

        Task<ActionResultDto> DeleteKaizanCardHeader(RequestDto<KaizenCardHeaderDto> kaizanCardDto);

    }


}
