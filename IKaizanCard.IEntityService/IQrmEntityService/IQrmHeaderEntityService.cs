using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Data.Entity.Entities.Qrm;
using Lean.Data.IEntityService.EntityDTO.QrmDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Data.IEntityService.IQrmEntityService
{
    public interface IQrmHeaderEntityService
    {
        Task<ActionResultDto> CreateQrmHeader(RequestDto<QrmHeaderDto> QrmHeaderDto);

        Task<int> CreateQrmHeader(QrmHeader QrmHeaderDto);
    }
}
