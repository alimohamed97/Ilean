using Data.Auth.EntityService.Dto.Privilege;
using Data.Entity.Entities;
using IRepository.Data;
using Resources;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Auth.EntityService
{
    internal class PrivilageEntityService : BaseAuthEntityService, IPrivilageEntityService
    {
        #region CTRS
        public PrivilageEntityService(IUnitOfWork unitOfWork, IMessageResourceReader message) : base(unitOfWork, message)
        {
        }
        #endregion

        public async Task<List<UserPagesDto>> GetSystemPagesByUserId(int userId, int languageId)
        {
            List<UserPagesDto> result = new List<UserPagesDto>();
            User user = await UnitOfWork.User.FirstOrDefaultAsync(s => s.UserId == userId);

            if (user != null)
            {
                List<PageLocalization> pageLocalize = await UnitOfWork.PageLocalization.GetWhereAsync(a => a.DeleteStatus !=0 );

                if (user.RoleId == 1 || user.UserTypeId == 1)
                {
                    List<Page> allPages = await UnitOfWork.Page.GetWhereAsync(a => a.DeleteStatus == 1);
                   
                    result.AddRange(allPages.Select(a => new UserPagesDto
                    {
                        SystemPageId = a.PageId,
                        ParentPageId = a.ParentPageId,
                        PageLink = a.PageUrl,
                        PageTitle = GetPageName(pageLocalize, a.PageId, languageId),
                        MenuOrder = a.MenuOrder,
                        PageIcon = a.PageIcon,
                    }).ToList());
                }
                else if (user?.RoleId != null && user.UserTypeId !=1)
                {
                    List<Page> rootPages = await GetRootPages();
                    List<PageAction> actionPage = await GetRolePrivilege(user.RoleId.GetValueOrDefault(default));

                    List<UserPagesDto> rootPageList = rootPages.Select(a => new UserPagesDto
                    {
                        SystemPageId = a.PageId,
                        ParentPageId = a.ParentPageId != null ? a.ParentPageId : null,
                        PageLink = a.PageUrl,
                        PageTitle = GetPageName(pageLocalize, a.PageId, languageId),
                        MenuOrder = a.MenuOrder,
                        PageIcon = a.PageIcon
                    }).ToList();

                    List<UserPagesDto> PageList = new List<UserPagesDto>();
                    foreach (var va in actionPage)
                    {
                        if (!PageList.Any(a => a.SystemPageId == va.PageId))
                        {
                            UserPagesDto PageDto = new UserPagesDto
                            {
                                SystemPageId = va.Page.PageId,
                                ParentPageId = va.Page.ParentPageId,
                                PageLink = va.Page.PageUrl,
                                PageTitle = GetPageName(pageLocalize, va.Page.PageId, languageId),
                                MenuOrder = va.Page.MenuOrder,
                                PageIcon = va.Page.PageIcon,
                            };

                            PageList.Add(PageDto);
                        }
                    }

                    result.AddRange(rootPageList.Where(v => PageList.Select(a => a.ParentPageId).ToList().Contains(v.SystemPageId)));
                    result.AddRange(PageList);
                }


            }

            return result.OrderBy(c => c.MenuOrder).ToList();
        }

        public async Task<UserPagePrivilege> GetUserPagePrivilege(int userId, int pageId)
        {
            UserPagePrivilege result = new UserPagePrivilege { UserCanView = false, UserCanAdd = false, UserCanEdit = false, UserCanDelete = false };

            User user = await UnitOfWork.User.FirstOrDefaultAsync(s => s.UserId == userId);
            if (user != null)
            {
                if (user.UserTypeId == 1)
                {
                    result.UserCanView = true;
                    result.UserCanAdd = true;
                    result.UserCanEdit = true;
                    result.UserCanDelete = true;
                }
                //else
                //{
                //    if (user.RoleId.HasValue)
                //    {
                //        List<PageAction> actions = await UnitOfWork.PageAction.GetWhereAsync(x => x.DeleteStatus == (byte)DeleteStatus.NotDeleted && x.PageId == pageId && x.RolePageAction.Any(a => a.RoleId == user.RoleId.Value));

                //        result.UserCanView = actions.Any(a => a.ActionTypeId == (int)Core.Enum.Security.ActionType.View);
                //        result.UserCanAdd = actions.Any(a => a.ActionTypeId == (int)Core.Enum.Security.ActionType.Add);
                //        result.UserCanEdit = actions.Any(a => a.ActionTypeId == (int)Core.Enum.Security.ActionType.Edit);
                //        result.UserCanDelete = actions.Any(a => a.ActionTypeId == (int)Core.Enum.Security.ActionType.Delete);
                //    }
                //}
            }
            return result;
        }

        #region Private Mathods
        private async Task<List<Page>> GetRootPages()
        {
            List<Page> perantList = await UnitOfWork.Page.GetWhereAsync(x => x.DeleteStatus == (byte)0 && x.ParentPageId != null);
            List<int> perentListIds = perantList.Select(a => a.ParentPageId.Value).ToList();

            return await UnitOfWork.Page.GetWhereAsync(x => x.DeleteStatus == 0 && perentListIds.Contains(x.PageId));
        }

        private async Task<List<PageAction>> GetRolePrivilege(int roleId)
        {
            return await UnitOfWork.PageAction.GetWhereAsync(x => x.DeleteStatus == 0 , "Page");
        }

        private string GetPageName(List<PageLocalization> pageLocalize, int pageId, int languageId)
        {
            PageLocalization localizationDataDto = pageLocalize.FirstOrDefault(a => a.PageId == pageId );
            if (localizationDataDto == null)
            {
                localizationDataDto = pageLocalize.FirstOrDefault(a => a.PageId == pageId);
            }
            return localizationDataDto?.PageName;
        }
        #endregion
    }
}
