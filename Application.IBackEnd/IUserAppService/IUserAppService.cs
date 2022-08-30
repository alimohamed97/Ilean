using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.IBackEnd.IUserAppService
{
   public interface IUserAppService
    {
        Task<ResponseDto<UserDto>> GetUserById(RequestDto<IdentityDto<int>> request);
        Task<ResponseDto<PageList<UserDto>>> GetAllUsers();
        Task<ResponseDto<UserDto>> GeUserByStuffNumber(RequestDto<IdentityDto<long>> request);

      
    }
}
