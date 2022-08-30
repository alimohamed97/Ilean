using Application.Auth;
using Core.Common.Dto.Action;
using Core.Common.Dto.Request;
using Core.Common.Dto.Response;
using Lean.Data.IEntityService.DTO;
using Data.Entity.Entities;
using IRepository.Data;
using Lean.Data.EntityService.Base;
using Lean.Data.IEntityService.IUsersEntityService;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Resources;
using System.Linq;

namespace Lean.Data.EntityService.UserEntityService
{
    internal class UserEntityService : BaseEntityService, IUsersEntityService
    {
        public UserEntityService(IUnitOfWork unitOfWork, IMessageResourceReader messageResource) : base(unitOfWork, messageResource)
        {
        }

        public Task<ActionResultDto> CreateUser(RequestDto<UserDto> UserDto)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResultDto> DeleteUser(RequestDto<UserDto> UserDto)
        {
            throw new NotImplementedException();
        }

        public async Task<PageList<UserDto>> GetAllUserList()
        {
            PageList<UserDto> pageList = new PageList<UserDto>();

            Expression<Func<User, bool>> filter = a=> a.UserId > 0;

            List<User> UserList = new List<User>(UnitOfWork.User.GetAll());

            if (UserList?.Count > default(int))
            {
                var userListDto = new List<UserDto>();
                foreach (User _user in UserList)
                {
                    userListDto.Add(new UserDto
                    {
                        UserId = _user.UserId,
                        UserName = _user.UserName,
                        DepartmentID = _user.DepartmentID,
                        SectionID = _user.SectionID,
                        StuffNo = _user.StuffNumber.ToString(),
                        DepartmentName = _user.Department.DepartmentName,
                        SectionName = _user.Section.SectionName
                    });
                }

                pageList.SetResult(await UnitOfWork.User.GetCount(filter), userListDto);
            }

            return pageList;
        }

        public async Task<UserDto> GeUserByID(RequestDto<IdentityDto<int>> UserID)
        {
            var result = new ActionResultDto();

            if (UserID.RequestData.Identity <= 0) return null;

            User _user = await UnitOfWork.User.FirstOrDefaultAsync(a => a.UserId 
            == UserID.RequestData.Identity);

            if (_user != null)
            {

                UserDto _userDto = new UserDto()
                {
                    UserId = _user.UserId,
                    UserName = _user.UserName,
                    DepartmentID = _user.DepartmentID,
                    SectionID = _user.SectionID,
                    StuffNo = _user.StuffNumber.ToString(),
                    DepartmentName = _user.Department.DepartmentName,
                    SectionName = _user.Section.SectionName
                };
                return _userDto;
            }
       
            return null;
        }

        public async Task<UserDto> GeUserByStuffNumber(RequestDto<IdentityDto<long>> StuffNumber)
        {
            var result = new ActionResultDto();

            if(StuffNumber.RequestData.Identity <= 0) return null;

            User _user = await UnitOfWork.User.FirstOrDefaultAsync(a => a.StuffNumber 
            == StuffNumber.RequestData.Identity);

            if (_user != null)
            {
                UserDto _userDto = new UserDto()
                {
                    UserId = _user.UserId,
                    UserName = _user.UserName,
                    DepartmentID = _user.DepartmentID,
                    SectionID = _user.SectionID,
                    StuffNo = _user.StuffNumber.ToString(),
                    DepartmentName = _user.Department.DepartmentName,
                    SectionName = _user.Section.SectionName
                };

                return _userDto;

            }

           

            return null;
        }

        public async Task<ActionResultDto> UpdateUser(RequestDto<UserDto> UserDto)
        {
            throw new NotImplementedException();
        }
    }
   
}
