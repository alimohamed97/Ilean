using Data.Auth.EntityService.Dto.Privilege;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Application.Auth.Application
{
    public interface IPrivilegeAppService
    {
        Task<List<UserPagesDto>> GetSystemPagesByUserId(int userId, int languageId);
        Task<UserPagePrivilege> GetUserPagePrivilege(int userId, int pageId);
    }
}
