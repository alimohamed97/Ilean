using Application.Auth.Setting;
using Data.Auth.EntityService;
using Data.Auth.EntityService.Dto.Privilege;
using Resources;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace Application.Auth.Application
{
    internal class PrivilegeAppService : BaseAppService, IPrivilegeAppService
    {
        #region CTRS
        private IPrivilageEntityService PrivilegeEntityService { get; }

        public PrivilegeAppService(AuthSetting appSettings, IMessageResourceReader messageResource, IPrivilageEntityService privilageEntityService) : base(appSettings, messageResource)
        {
            PrivilegeEntityService = privilageEntityService;
        }
        #endregion

        public Task<List<UserPagesDto>> GetSystemPagesByUserId(int userId, int languageId)
        {
            return PrivilegeEntityService.GetSystemPagesByUserId(userId, languageId);
        }

        public Task<UserPagePrivilege> GetUserPagePrivilege(int userId, int pageId)
        {
            return PrivilegeEntityService.GetUserPagePrivilege(userId, pageId);
        }
    }
}
