using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Data.IEntityService.IUsersEntityService
{
    public interface IUsersEntityService
    {
        Task<ActionResultDto> CreateUser(RequestDto<UserDto> UserDto);
        Task<UserDto> GeUserByID(RequestDto<IdentityDto<int>> UserID);
        Task<PageList<UserDto>> GetAllUserList();
        Task<ActionResultDto> UpdateUser(RequestDto<UserDto> UserDto);
        Task<ActionResultDto> DeleteUser(RequestDto<UserDto> UserDto);
        Task<UserDto> GeUserByStuffNumber(RequestDto<IdentityDto<long>> StuffNumber);
    }
}
